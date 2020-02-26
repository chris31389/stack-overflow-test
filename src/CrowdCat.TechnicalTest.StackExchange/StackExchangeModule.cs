using CrowdCat.TechnicalTest.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace CrowdCat.TechnicalTest.StackExchange
{
    public static class StackExchangeModule
    {
        public static IServiceCollection AddStackExchangeModule(this IServiceCollection serviceCollection) =>
            serviceCollection
                .AddScoped<IQuestionRepository, QuestionRepository>();
    }
}