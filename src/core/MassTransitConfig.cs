using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using System;
using System.Threading.Tasks;

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
                cfg.Host("rabbitmq://localhost:5672", host =>
                {
                    host.Username("guest");
                    host.Password("guest");
                });
            });
            bus.Start();
            return bus;
        }
    }
}
