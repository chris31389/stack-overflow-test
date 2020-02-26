using System;

namespace CrowdCat.TechnicalTest.ConsoleApp
{
    public class ConsoleAppService
    {
        private readonly IDateParser _dateParser;

        public ConsoleAppService(IDateParser dateParser)
        {
            _dateParser = dateParser ?? throw new ArgumentNullException(nameof(dateParser));
        }

        public void Run(string[] args)
        {
            // An argument parser could be used here
            if (args.Length == 0)
            {
                Console.WriteLine("A date must be provided in the format yyyy-MM-dd");

                // No date provided so terminate early
                return;
            }

            DateTime? dateTime = _dateParser.Parse(args[0]);
            if (!dateTime.HasValue)
            {
                Console.WriteLine($"the input date '{args[0]}' must be provided in the format yyyy-MM-dd");

                // No date could be parsed so terminate early
                return;
            }

            Console.WriteLine(dateTime.Value.ToString("yyyy-MM-dd"));
        }
    }
}