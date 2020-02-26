using System.Collections.Generic;

namespace CrowdCat.TechnicalTest.ConsoleApp
{
    public interface ITagFormatter
    {
        string Format(IEnumerable<string> uniqueTags);
    }
}