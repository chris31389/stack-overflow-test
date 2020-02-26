using System;
using System.Threading.Tasks;
using CrowdCat.TechnicalTest.Application;

namespace CrowdCat.TechnicalTest.ConsoleApp
{
    public class ConsoleAppService
    {
        private readonly IDateParser _dateParser;
        private readonly IDaySummaryService _daySummaryService;
        private readonly ITagFormatter _tagFormatter;

        public ConsoleAppService(
            IDateParser dateParser,
            IDaySummaryService daySummaryService,
            ITagFormatter tagFormatter)
        {
            _dateParser = dateParser ?? throw new ArgumentNullException(nameof(dateParser));
            _daySummaryService = daySummaryService ?? throw new ArgumentNullException(nameof(daySummaryService));
            _tagFormatter = tagFormatter ?? throw new ArgumentNullException(nameof(tagFormatter));
        }

        public async Task Run(string[] args)
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

            DaySummaryDto daySummaryDto = await _daySummaryService.GetSummaryAsync(dateTime.Value);
            if (daySummaryDto == null)
            {
                Console.WriteLine(
                    $"an error occured when trying to retrieve the summary for the date '{dateTime.Value}'. " +
                    $"Please try again.");

                // Unable to retrieve summary properly, so terminate early
                return;
            }

            Console.WriteLine($"Summary for date: {dateTime.Value:yyyy-MM-dd}");
            Console.WriteLine($"Total questions: {daySummaryDto.QuestionTotal}");
            Console.WriteLine($"Total views: {daySummaryDto.ViewTotal}");
            Console.WriteLine("Tags:");

            string tags = _tagFormatter.Format(daySummaryDto.UniqueTags);
            Console.WriteLine(tags);
        }
    }
}