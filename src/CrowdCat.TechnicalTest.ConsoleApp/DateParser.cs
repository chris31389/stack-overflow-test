using System;

namespace CrowdCat.TechnicalTest.ConsoleApp
{
    public class DateParser : IDateParser
    {
        public DateTime? Parse(string date)
        {
            // Validation could be added here

            return DateTime.TryParse(date, out DateTime dateTime)
                ? dateTime
                : default(DateTime?);
        }
    }
}