using System.Threading.Tasks;
using CrowdCat.TechnicalTest.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace CrowdCat.TechnicalTest.ConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddConsoleModule()
                .AddAppModule()
                .BuildServiceProvider();

            ConsoleAppService consoleAppService = serviceProvider.GetService<ConsoleAppService>();
            await consoleAppService.Run(args);
        }
    }
}