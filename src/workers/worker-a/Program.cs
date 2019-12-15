using Autofac.Extensions.DependencyInjection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Autofac;
using ResilientIntegration.Core.Infrastructure;

namespace ResilientIntegration.WorkerA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory((builder) =>
                {
                    builder.RegisterModule<WorkerAModule>();
                    builder.RegisterModule<BusModule>();
                }))
                .ConfigureLogging((logging) =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddAutofac();
                    services.AddLogging();
                    services.AddMassTransit(mt =>
                    {
                        mt.AddConsumers(Assembly.GetExecutingAssembly());
                    });
                    services.AddHostedService<Worker>();
                });
    }
}
