using Microsoft.Extensions.Hosting;

namespace DiscoBot.Services
{
    public class DatabaseStartupService : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
        }
    }
}
