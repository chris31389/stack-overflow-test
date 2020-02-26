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
        private readonly IAppOutput _appOutput;

        public ConsoleAppService(
            IDateParser dateParser,
            IDaySummaryService daySummaryService,
            ITagFormatter tagFormatter,
            IAppOutput appOutput)
        {
            _dateParser = dateParser ?? throw new ArgumentNullException(nameof(dateParser));
            _daySummaryService = daySummaryService ?? throw new ArgumentNullException(nameof(daySummaryService));
            _tagFormatter = tagFormatter ?? throw new ArgumentNullException(nameof(tagFormatter));
            _appOutput = appOutput ?? throw new ArgumentNullException(nameof(appOutput));
        }

        public async Task Run(string[] args)
        {
            // An argument parser could be used here
            if (args.Length == 0)
            {
                _appOutput.WriteLine("A date must be provided in the format yyyy-MM-dd");

                // No date provided so terminate early
                return;
            }

            DateTime? dateTime = _dateParser.Parse(args[0]);
            if (!dateTime.HasValue)
            {
                _appOutput.WriteLine($"the input date '{args[0]}' must be provided in the format yyyy-MM-dd");

                // No date could be parsed so terminate early
                return;
            }

            DaySummaryDto daySummaryDto = await _daySummaryService.GetSummaryAsync(dateTime.Value);
            if (daySummaryDto == null)
            {
                _appOutput.WriteLine(
                    $"an error occured when trying to retrieve the summary for the date '{dateTime.Value}'. " +
                    $"Please try again.");

                // Unable to retrieve summary properly, so terminate early
                return;
            }

            _appOutput.WriteLine($"Summary for date: {dateTime.Value:yyyy-MM-dd}");
            _appOutput.WriteLine($"Total questions: {daySummaryDto.QuestionTotal}");
            _appOutput.WriteLine($"Total views: {daySummaryDto.ViewTotal}");
            _appOutput.WriteLine("Tags:");

            string tags = _tagFormatter.Format(daySummaryDto.UniqueTags);
            _appOutput.WriteLine(tags);
        }
    }
}