using System.Collections.Generic;
// ReSharper disable InconsistentNaming

namespace CrowdCat.TechnicalTest.StackExchange
{
    public class QuestionJsonObject
    {
        public IEnumerable<QuestionItemJsonObject> items { get; set; }
        public bool has_more { get; set; }
    }
}