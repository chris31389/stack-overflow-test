using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CrowdCat.TechnicalTest.StackExchange
{
    public class QuestionClient : IQuestionClient
    {
        public const string ClientName = "question";
        private readonly IHttpClientFactory _httpClientFactory;
        private HttpClient httpClient;

        public QuestionClient(
            IHttpClientFactory httpClientFactory
        )
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<string> GetAsync(double fromDate, double toDate, int page)
        {
            if (httpClient == null)
            {
                httpClient = _httpClientFactory.CreateClient(ClientName);
            }
            
            string url = GetUrl(page++, fromDate, toDate);
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
            string rawJson = await httpResponseMessage.Content.ReadAsStringAsync();
            return rawJson;
        }
        
        /// <summary>
        /// Example Response:
        /// {
        ///     "tags": [
        ///     "vb.net",
        ///     "rdlc",
        ///     "reportviewer"
        ///         ],
        ///     "view_count": 1
        /// }
        /// </summary>
        /// <param name="page"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        private static string GetUrl(int page, double fromDate, double toDate) =>
            "questions" +
            "?site=stackoverflow" +
            "&pagesize=100" +
            $"&page={page}" +
            "&order=asc" +
            $"&fromdate={fromDate}" +
            $"&todate={toDate}" +
            "&filter=!C(o2z_hLK.n0l1_7t";
    }
}