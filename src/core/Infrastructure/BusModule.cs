using Autofac;
using MassTransit;

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
                    });
                })
                .SingleInstance()
                .As<IBusControl>()
                .As<IBus>();
        }
    }
}
