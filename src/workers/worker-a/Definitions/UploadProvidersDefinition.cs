//using MassTransit;
//using MassTransit.ConsumeConfigurators;
//using MassTransit.Definition;
//using ResilientIntegration.WorkerA.Consumers;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ResilientIntegration.WorkerA.Definitions
//{
//    public class UploadProvidersDefinition : ConsumerDefinition<UploadProvidersConsumer>
//    {
//        public UploadProvidersDefinition()
//        {
//            EndpointName = "ha-submit-order";
//            ConcurrentMessageLimit = 4;
//        }

//        protected override void ConfigureConsumer(
//            IReceiveEndpointConfigurator endpointConfigurator,
//            IConsumerConfigurator<UploadProvidersConsumer> consumerConfigurator)
//        {
//            consumerConfigurator.
//        }
//    }
//}
