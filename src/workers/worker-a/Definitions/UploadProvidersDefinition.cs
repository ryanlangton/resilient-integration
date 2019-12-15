using GreenPipes;
using MassTransit;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;
using ResilientIntegration.WorkerA.Consumers;

namespace ResilientIntegration.WorkerA.Definitions
{
    public class UploadProvidersDefinition : ConsumerDefinition<UploadProvidersConsumer>
    {
        public UploadProvidersDefinition()
        {
            EndpointName = "upload-providers";
            ConcurrentMessageLimit = 4;
        }

        protected override void ConfigureConsumer(
            IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<UploadProvidersConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseInMemoryOutbox();
            endpointConfigurator.UseMessageRetry(r => r.Interval(3, 1000));
        }
    }
}
