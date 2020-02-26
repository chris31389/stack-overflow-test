using System.Threading.Tasks;
using CrowdCat.TechnicalTest.DependencyInjection;
using CrowdCat.TechnicalTest.StackExchange;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;

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

    public class TestQuestionClient : IQuestionClient
    {
        private string FirstResponse => JsonConvert.SerializeObject(new
        {
            items = new[]
            {
                new
                {
                    view_count = 33,
                    tags = new[] {"a", "b", "z", "d"}
                },
                new
                {
                    view_count = 21,
                    tags = new[] {"a", "z", "d"}
                },
                new
                {
                    view_count = 1,
                    tags = new[] {"d"}
                }
            },
            has_more = true
        });

        private string SecondResponse => JsonConvert.SerializeObject(new
        {
            items = new[]
            {
                new
                {
                    view_count = 33,
                    tags = new[] {"a", "b", "z", "d"}
                },
                new
                {
                    view_count = 21,
                    tags = new[] {"a", "z", "d"}
                }
            },
            has_more = false
        });

        public Task<string> GetAsync(double fromDate, double toDate, int page)
        {
            string response;
            switch (page)
            {
                case 1:
                    response = FirstResponse;
                    break;
                case 2:
                    response = SecondResponse;
                    break;
                default:
                    response = null;
                    break;
            }

            return Task.FromResult(response);
        }
    }
}