using System.Threading.Tasks;
using CrowdCat.TechnicalTest.DependencyInjection;
using CrowdCat.TechnicalTest.StackExchange;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CrowdCat.TechnicalTest.ConsoleApp.Tests
{
    public class TestProgram
    {
        public static async Task Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddConsoleModule()
                .AddAppModule()
                // Replace services that have already been added
                .Replace(ServiceDescriptor.Scoped<IQuestionClient, TestQuestionClient>())
                .BuildServiceProvider();

            ConsoleAppService consoleAppService = serviceProvider.GetService<ConsoleAppService>();
            await consoleAppService.Run(args);
        }
    }
}