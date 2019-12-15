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
            //throw new Exception("some random exception happened!");
            var logPath = Path.GetTempFileName();
            var logFile = File.Create($"{logPath}.json");
            var logWriter = new StreamWriter(logFile);
            await logWriter.WriteLineAsync(JsonConvert.SerializeObject(context.Message, Formatting.Indented));
            _logger.LogInformation($"Wrote providers to {logFile.Name}");
            logWriter.Dispose();
        }
    }
}
