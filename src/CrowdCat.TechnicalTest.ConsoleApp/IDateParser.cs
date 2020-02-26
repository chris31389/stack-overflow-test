using System;

namespace CrowdCat.TechnicalTest.ConsoleApp
{
    public interface IDateParser
    {
        DateTime? Parse(string date);
    }
}