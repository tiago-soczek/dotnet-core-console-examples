using Contoso.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Contoso.FullHost
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureAppConfiguration(builder =>
                {
                    builder.AddJsonFile("appsettings.json");
                })
                .ConfigureLogging(builder =>
                {
                    builder.AddConsole();
                    builder.SetMinimumLevel(LogLevel.Trace);
                })
                .ConfigureServices((context, services) =>
                {
                    var section = context.Configuration.GetSection("contoso");

                    services.Configure<ContosoOptions>(section);

                    services.AddHostedService<ExecuteOneTimeService>();
                    // services.AddHostedService<TimerService>();
                })
                // .RunConsoleAsync()
                .Build();

            using (host)
            {
                await host.StartAsync();

                await host.StopAsync();
            }
        }
    }
}
