using System;
using CrowdCat.TechnicalTest.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace CrowdCat.TechnicalTest.StackExchange
{
    public static class StackExchangeModule
    {
        public static IServiceCollection AddStackExchangeModule(this IServiceCollection serviceCollection) =>
            serviceCollection
                .AddScoped<IQuestionRepository, QuestionRepository>()
                .AddHttpClient(QuestionRepository.ClientName, options =>
                {
                    options.BaseAddress = new Uri("https://api.stackexchange.com/2.2");
                })
                .Services;
    }
}