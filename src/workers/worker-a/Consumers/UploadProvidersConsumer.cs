using System;
using System.Threading.Tasks;
using MassTransit;
using ResilientIntegration.Core.Commands;

namespace ResilientIntegration.WorkerA.Consumers
{
    public class UploadProvidersConsumer : IConsumer<UploadProvidersCommand>
    {
        public UploadProvidersConsumer()
        {
            Console.Write("Upload providers consumer created");
        }

        public Task Consume(ConsumeContext<UploadProvidersCommand> context)
        {
            throw new System.NotImplementedException();
        }
    }
}
