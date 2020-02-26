using System.Collections;
using System.Collections.Generic;
using CrowdCat.TechnicalTest.Domain;

namespace CrowdCat.TechnicalTest.StackExchange
{
    public class QuestionResponse
    {
        public bool HasMore { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}