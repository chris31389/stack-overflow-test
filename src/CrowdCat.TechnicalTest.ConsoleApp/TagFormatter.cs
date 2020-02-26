using System.Collections.Generic;
using System.Linq;

namespace CrowdCat.TechnicalTest.ConsoleApp
{
    public class TagFormatter : ITagFormatter
    {
        public string Format(IEnumerable<string> uniqueTags)
        {
            // return empty string if nothing is provided
            if (uniqueTags == null) return "";

            string[] tags = uniqueTags
                .Distinct()
                .ToArray();

            return string.Join(",", tags);
        }
    }
}