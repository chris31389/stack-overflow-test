using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CrowdCat.TechnicalTest.Domain;

namespace CrowdCat.TechnicalTest.StackExchange
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IQuestionClient _questionClient;
        private readonly IJsonMapper _jsonMapper;

        public QuestionRepository(
            IQuestionClient questionClient,
            IJsonMapper jsonMapper)
        {
            _questionClient = questionClient ?? throw new ArgumentNullException(nameof(questionClient));
            _jsonMapper = jsonMapper;
        }

        public async Task<IEnumerable<Question>> GetAllForDate(DateTime date)
        {
            DateTime wholeDay = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, DateTimeKind.Utc);
            double fromDate = wholeDay.ToUnixTimestamp();
            double toDate = wholeDay.AddDays(1).ToUnixTimestamp();
            int page = 1;
            List<Question> questions = new List<Question>();
            bool hasMore;
            do
            {
                string rawJson = await _questionClient.GetAsync(fromDate, toDate, page++);
                QuestionResponse questionResponse = _jsonMapper.Map(rawJson);
                questions.AddRange(questionResponse.Questions);
                hasMore = questionResponse.HasMore;
            } while (hasMore);

            return questions;
        }
    }
}