using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CrowdCat.TechnicalTest.Domain;

namespace CrowdCat.TechnicalTest.StackExchange
{
    public class QuestionRepository : IQuestionRepository
    {
        public async Task<IEnumerable<Question>> GetAllForDate(DateTime date)
        {
            return await Task.FromResult(new List<Question>());
        }
    }
}