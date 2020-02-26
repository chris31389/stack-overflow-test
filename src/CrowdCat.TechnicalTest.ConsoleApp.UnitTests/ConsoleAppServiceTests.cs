using System;
using System.Threading.Tasks;
using CrowdCat.TechnicalTest.Application;
using Moq;
using NUnit.Framework;

namespace CrowdCat.TechnicalTest.ConsoleApp.UnitTests
{
    [TestFixture]
    public class ConsoleAppServiceTests
    {
        private Mock<IDateParser> _dateParserMock;
        private Mock<IDaySummaryService> _daySummaryServiceMock;
        private Mock<ITagFormatter> _tagFormatterMock;
        private TestAppOutput _testAppOutput;
        private ConsoleAppService _consoleAppService;

        [SetUp]
        public void Setup()
        {
            _dateParserMock = new Mock<IDateParser>();
            _daySummaryServiceMock = new Mock<IDaySummaryService>();
            _tagFormatterMock = new Mock<ITagFormatter>();
            _testAppOutput = new TestAppOutput();
            _consoleAppService = new ConsoleAppService(
                _dateParserMock.Object,
                _daySummaryServiceMock.Object,
                _tagFormatterMock.Object,
                _testAppOutput
            );
        }

        [Test]
        public async Task GivenValidDate_WhenIRun_ThenASummaryIsOutput()
        {
            // Arrange
            string validDate = "2019-03-01";
            DateTime? dateTime = new DateTime(2019, 3, 1);
            _dateParserMock.Setup(x => x.Parse(validDate)).Returns(dateTime);

            DaySummaryDto daySummaryDto = new DaySummaryDto
            {
                QuestionTotal = 14,
                ViewTotal = 15415,
                UniqueTags = new[] {"z"}
            };

            _daySummaryServiceMock
                .Setup(x => x.GetSummaryAsync(dateTime.Value))
                .ReturnsAsync(daySummaryDto);

            string formattedTags = "tags!";
            _tagFormatterMock.Setup(x => x.Format(daySummaryDto.UniqueTags)).Returns(formattedTags);

            // Act
            await _consoleAppService.Run(new[] {validDate});

            // Assert
            string[] outputs = _testAppOutput.Outputs.ToArray();
            Assert.That(outputs[0], Is.EqualTo("Summary for date: " + validDate));
            Assert.That(outputs[1], Is.EqualTo($"Total questions: {daySummaryDto.QuestionTotal}"));
            Assert.That(outputs[2], Is.EqualTo($"Total views: {daySummaryDto.ViewTotal}"));
            Assert.That(outputs[4], Is.EqualTo(formattedTags));
        }
    }
}