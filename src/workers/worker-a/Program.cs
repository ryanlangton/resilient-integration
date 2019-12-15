using Autofac.Extensions.DependencyInjection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ResilientIntegration.WorkerA.Consumers;
using System;
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
                        cfg.AddBus(CreateBus);
                        cfg.AddConsumers(Assembly.GetExecutingAssembly());
                    });
                    services.AddHostedService<Worker>();
                });

        public static IBusControl CreateBus(IServiceProvider provider)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host("rabbitmq://localhost:15672");

                cfg.ReceiveEndpoint("upload-providers", ep =>
                {
                    ep.PrefetchCount = 16;
                    ep.ConfigureConsumer<UploadProvidersConsumer>(provider);
                });
                
            });
        }
    }
}
