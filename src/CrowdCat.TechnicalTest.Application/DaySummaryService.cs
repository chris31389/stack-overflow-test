using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdCat.TechnicalTest.Domain;

namespace CrowdCat.TechnicalTest.Application
{
    public class DaySummaryService : IDaySummaryService
    {
        private readonly IQuestionRepository _questionRepository;

        public DaySummaryService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
        }

        public async Task<DaySummaryDto> GetSummaryAsync(DateTime dateTime)
        {
            IEnumerable<Question> questionResults = await _questionRepository.GetAllForDate(dateTime);
            IEnumerable<Question> questions = questionResults?.ToList() ?? new List<Question>();

            DaySummaryDto daySummaryDto = new DaySummaryDto
            {
                QuestionTotal = questions.Count(),
                UniqueTags = questions.SelectMany(question => question.Tags).Distinct(),
                ViewTotal = questions.Sum(x => x.ViewTotal)
            };

            return await Task.FromResult(daySummaryDto);
        }
    }
}