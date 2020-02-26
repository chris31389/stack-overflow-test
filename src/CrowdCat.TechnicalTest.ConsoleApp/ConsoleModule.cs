using Microsoft.Extensions.DependencyInjection;

namespace CrowdCat.TechnicalTest.ConsoleApp
{
    public static class ConsoleModule
    {
        public static IServiceCollection AddConsoleModule(this IServiceCollection serviceCollection) => serviceCollection
            .AddTransient<IDateParser, DateParser>()
            .AddTransient<ITagFormatter, TagFormatter>()
            .AddTransient<IAppOutput, AppOutput>()
            .AddTransient<ConsoleAppService>();
    }
}