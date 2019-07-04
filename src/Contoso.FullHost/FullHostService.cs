using System.Threading;
using System.Threading.Tasks;
using Contoso.Shared;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Contoso.FullHost
{
    public class ExecuteOneTimeService : IHostedService
    {
        private readonly IOptions<ContosoOptions> options;
        private readonly ILogger<ExecuteOneTimeService> logger;

        public ExecuteOneTimeService(IOptions<ContosoOptions> options, ILogger<ExecuteOneTimeService> logger)
        {
            this.options = options;
            this.logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug(options.Value.ToString());

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}