using System;
using System.Threading.Tasks;

namespace CrowdCat.TechnicalTest.Application
{
    public class DaySummaryService : IDaySummaryService
    {
        public async Task<DaySummaryDto> GetSummaryAsync(DateTime dateTime)
        {
            DaySummaryDto daySummaryDto = new DaySummaryDto
            {
                QuestionTotal = 10,
                UniqueTags = new[] {"d", "b", "a", "c"},
                ViewTotal = 2314
            };

            return await Task.FromResult(daySummaryDto);
        }
    }
}