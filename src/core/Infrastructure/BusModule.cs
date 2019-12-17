using Autofac;
using MassTransit;
using MassTransit.Azure.ServiceBus.Core;
using Microsoft.Extensions.Logging;

namespace ResilientIntegration.Core.Infrastructure
{
    public class BusModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                return Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host("rabbitmq://localhost:5672", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });
                    cfg.ReceiveEndpoint("resilient-integration", ec =>
                    {
                        ec.ConfigureConsumers(context);
                    });
                    var logFactory = context.Resolve<ILoggerFactory>();
                    cfg.SetLoggerFactory(logFactory);
                });
                //return Bus.Factory.CreateUsingAzureServiceBus(cfg =>
                //{
                //    cfg.Host("www://azure-endpoint", host =>
                //    {
                //        host.Username("guest");
                //        host.Password("guest");
                //    });
                //    cfg.ReceiveEndpoint("resilient-integration", ec =>
                //    {
                //        ec.ConfigureConsumers(context);
                //    });
                //    var logFactory = context.Resolve<ILoggerFactory>();
                //    cfg.SetLoggerFactory(logFactory);
                //});
            })
            .SingleInstance()
            .As<IBusControl>()
            .As<IBus>();
        }
    }
}
