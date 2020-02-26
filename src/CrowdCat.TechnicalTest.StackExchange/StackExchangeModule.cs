using System;
using System.Net;
using System.Net.Http;
using CrowdCat.TechnicalTest.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace CrowdCat.TechnicalTest.StackExchange
{
    public static class StackExchangeModule
    {
        public static IServiceCollection AddStackExchangeModule(this IServiceCollection serviceCollection) =>
            serviceCollection
                .AddScoped<IQuestionRepository, QuestionRepository>()
                .AddHttpClient(QuestionClient.ClientName,
                    options => { options.BaseAddress = new Uri("https://api.stackexchange.com/2.2"); })
                .ConfigurePrimaryHttpMessageHandler(messageHandlerBuilder => new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                })
                .Services
                .AddScoped<IQuestionClient, QuestionClient>()
                .AddTransient<IJsonMapper, JsonMapper>();
    }
}