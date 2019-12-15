using System.Threading.Tasks;
using MassTransit;
using ResilientIntegration.Core.Commands;

namespace ResilientIntegration.WorkerA.Consumers
{
    public class UploadProvidersConsumer : IConsumer<UploadProvidersCommand>
    {
        public Task Consume(ConsumeContext<UploadProvidersCommand> context)
        {
            throw new System.NotImplementedException();
        }
    }
}
