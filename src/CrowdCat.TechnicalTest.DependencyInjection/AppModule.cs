using CrowdCat.TechnicalTest.Application;
using CrowdCat.TechnicalTest.StackExchange;
using Microsoft.Extensions.DependencyInjection;

namespace CrowdCat.TechnicalTest.DependencyInjection
{
    public static class AppModule
    {
        public static IServiceCollection AddAppModule(this IServiceCollection serviceCollection) => serviceCollection
            .AddApplicationModule()
            .AddStackExchangeModule();
    }
}