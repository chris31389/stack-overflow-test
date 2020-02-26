using System.Collections.Generic;
// ReSharper disable InconsistentNaming

namespace CrowdCat.TechnicalTest.StackExchange
{
    public class QuestionItemJsonObject
    {
        public int view_count { get; set; }
        public IEnumerable<string> tags { get; set; }
    }
}