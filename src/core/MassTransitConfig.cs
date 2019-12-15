using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using MassTransit.RabbitMqTransport;
using System;

namespace ResilientIntegration.Core
{
    public static class MassTransitConfig
    {
        public static void Configure(IServiceCollectionConfigurator cfg)
        {
            cfg.AddBus(CreateBus);
        }

        public static IBusControl CreateBus(IServiceProvider serviceProvider)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                ConfigureBus(cfg);
            });
            bus.Start();
            return bus;
        }

        public static void ConfigureBus(IRabbitMqBusFactoryConfigurator cfg)
        {
            cfg.Host("rabbitmq://localhost:5672", host =>
            {
                host.Username("guest");
                host.Password("guest");
            });
        }
    }
}
