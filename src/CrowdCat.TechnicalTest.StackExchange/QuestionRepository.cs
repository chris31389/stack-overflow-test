using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CrowdCat.TechnicalTest.Domain;

namespace CrowdCat.TechnicalTest.StackExchange
{
    public class QuestionRepository : IQuestionRepository
    {
        public const string ClientName = "question";
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IJsonMapper _jsonMapper;

        public QuestionRepository(IHttpClientFactory httpClientFactory,
            IJsonMapper jsonMapper)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _jsonMapper = jsonMapper;
        }

        public async Task<IEnumerable<Question>> GetAllForDate(DateTime date)
        {
            DateTime wholeDay = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, DateTimeKind.Utc);
            double fromDate = wholeDay.ToUnixTimestamp();
            double toDate = wholeDay.AddDays(1).ToUnixTimestamp();
            int page = 1;
            HttpClient httpClient = _httpClientFactory.CreateClient(ClientName);
            List<Question> questions = new List<Question>();
            bool hasMore;
            do
            {
                string url = GetUrl(page++, fromDate, toDate);
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
                string rawJson = await httpResponseMessage.Content.ReadAsStringAsync();
                QuestionResponse questionResponse = _jsonMapper.Map(rawJson);
                questions.AddRange(questionResponse.Questions);
                hasMore = questionResponse.HasMore;
            } while (hasMore);

            return questions;
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