using System;
using System.IO;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ResilientIntegration.Core.Commands;

namespace ResilientIntegration.WorkerA.Consumers
{
    public class UploadProvidersConsumer : IConsumer<UploadProvidersCommand>
    {
        private readonly ILogger<UploadProvidersConsumer> _logger;

        public UploadProvidersConsumer(ILogger<UploadProvidersConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UploadProvidersCommand> context)
        {
            // _logger.LogError("something bad happened!");
            // throw new Exception();
            var filePath = Path.GetTempFileName();
            var outFile = File.Create($"{filePath}.json");
            var writer = new StreamWriter(outFile);
            await writer.WriteLineAsync(JsonConvert.SerializeObject(context.Message, Formatting.Indented));
            _logger.LogInformation($"Wrote providers to {outFile.Name}");
            writer.Dispose();
        }
    }
}
