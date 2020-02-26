using System.Collections.Generic;

namespace CrowdCat.TechnicalTest.Domain
{
    public class CreateQuestionDto
    {
        public IEnumerable<string> Tags { get; set; }
        public int ViewTotal { get; set; }
    }
}