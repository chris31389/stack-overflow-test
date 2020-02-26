using System.Collections;
using System.Collections.Generic;

namespace CrowdCat.TechnicalTest.Application
{
    public class DaySummaryDto
    {
        public int QuestionTotal { get; set; }
        public int ViewTotal { get; set; }
        public IEnumerable<string> UniqueTags { get; set; }
    }
}