using System;
using CrowdCat.TechnicalTest.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace CrowdCat.TechnicalTest.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddConsoleModule()
                .AddAppModule()
                .BuildServiceProvider();

            ConsoleAppService consoleAppService = serviceProvider.GetService<ConsoleAppService>();
            consoleAppService.Run(args);
        }
    }
}