using Autofac.Extensions.DependencyInjection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ResilientIntegration.Core;
using ResilientIntegration.WorkerA.Consumers;
using System.Reflection;

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
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(cfg =>
                    {
                        cfg.AddBus(MassTransitConfig.CreateBus);
                        //cfg.ReceiveEndpoint(host, "event_queue", e =>
                        //{
                        //    e.Handler<ValueEntered>(context =>
                        //        Console.Out.WriteLineAsync($"Value was entered: {context.Message.Value}"));
                        //})
                        cfg.AddConsumer<UploadProvidersConsumer>();
                        //cfg.AddConsumers(Assembly.GetExecutingAssembly());
                    });
                    services.AddHostedService<Worker>();
                });
    }
}
