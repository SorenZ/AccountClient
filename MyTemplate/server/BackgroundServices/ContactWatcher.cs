using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Smee.IO.Client;

namespace MyTemplate.server.BackgroundServices
{
    public class ContactWatcher: BackgroundService
    {
        private readonly ILogger<ContactWatcher> _logger;

        public ContactWatcher(ILogger<ContactWatcher> logger) {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            _logger.LogWarning("Start my smee");
            var smeeCli = new SmeeClient(new Uri("https://smee.io/6lM3El3gS3Ap4b3N"));

            smeeCli.OnConnect += (sender, args) => _logger.LogInformation("Connected to SMEE.io");
            smeeCli.OnMessage += (sender, myEvent) =>
            {
                _logger.LogInformation($"Message: {JsonConvert.SerializeObject(myEvent)}");
            };
            smeeCli.OnPing += (sender, args) => _logger.LogInformation("Ping from SMEE.io");
            
            await smeeCli.StartAsync(stoppingToken); // Token is optional here
        }
    
    }
}