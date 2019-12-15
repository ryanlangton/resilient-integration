using Autofac.Extensions.DependencyInjection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Autofac;
using ResilientIntegration.Core.Infrastructure;
using Serilog;
using Serilog.Events;
using Microsoft.Extensions.Configuration;
using MassTransit.Context;

namespace ResilientIntegration.WorkerA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
            Log.Information("Starting WorkerA host");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory((builder) =>
                {
                    builder.RegisterModule<WorkerAModule>();
                    builder.RegisterModule<BusModule>();
                }))
                .ConfigureLogging(loggingBuilder =>
                {
                    LogContext.ConfigureCurrentLogContext();
                    var configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();
                    var logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(configuration)
                        .CreateLogger();
                    loggingBuilder.AddSerilog(logger, dispose: true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddAutofac();
                    services.AddMassTransit(mt =>
                    {
                        mt.AddConsumers(Assembly.GetExecutingAssembly());
                    });
                    services.AddHostedService<Worker>();
                })
                .UseSerilog();

    }
}
