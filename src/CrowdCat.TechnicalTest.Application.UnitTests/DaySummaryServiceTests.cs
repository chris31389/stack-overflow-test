using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdCat.TechnicalTest.Domain;
using Moq;
using NUnit.Framework;

namespace CrowdCat.TechnicalTest.Application.UnitTests
{
    [TestFixture]
    public class DaySummaryServiceTests
    {
        private DaySummaryService _daySummaryService;
        private Mock<IQuestionRepository> _questionRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _questionRepositoryMock = new Mock<IQuestionRepository>();
            _daySummaryService = new DaySummaryService(
                _questionRepositoryMock.Object
            );
        }
        
        [Test]
        public async Task GivenQuestionList_WhenICallGetSummary_ThenASummaryIsReturnedWithATotal()
        {
            // Arrange
            DateTime dateTime = new DateTime(2013, 01, 4);
            List<Question> questions = new List<Question>
            {
                new Question(new CreateQuestionDto()),
                new Question(new CreateQuestionDto()),
                new Question(new CreateQuestionDto()),
                new Question(new CreateQuestionDto()),
            };
            _questionRepositoryMock
                .Setup(x => x.GetAllForDate(dateTime))
                .ReturnsAsync(questions);

            // Act
            DaySummaryDto daySummaryDto = await _daySummaryService.GetSummaryAsync(dateTime);

            // Assert
            Assert.That(daySummaryDto.QuestionTotal, Is.EqualTo(4));
        }

        [Test]
        public async Task GivenQuestionList_WhenICallGetSummary_ThenASummaryIsReturnedWithAViewTotal()
        {
            // Arrange
            DateTime dateTime = new DateTime(2013, 01, 4);
            List<Question> questions = new List<Question>
            {
                new Question(new CreateQuestionDto {ViewTotal = 3}),
                new Question(new CreateQuestionDto {ViewTotal = 4}),
                new Question(new CreateQuestionDto {ViewTotal = 1}),
            };
            _questionRepositoryMock
                .Setup(x => x.GetAllForDate(dateTime))
                .ReturnsAsync(questions);

            // Act
            DaySummaryDto daySummaryDto = await _daySummaryService.GetSummaryAsync(dateTime);

            // Assert
            Assert.That(daySummaryDto.ViewTotal, Is.EqualTo(8));
        }

        [Test]
        public async Task GivenQuestionList_WhenICallGetSummary_ThenASummaryIsReturnedWithASetOfDistinctTags()
        {
            // Arrange
            DateTime dateTime = new DateTime(2013, 01, 4);
            List<Question> questions = new List<Question>
            {
                new Question(new CreateQuestionDto {Tags = new[] {"x", "b", "z"}}),
                new Question(new CreateQuestionDto {Tags = new[] {"a", "c", "z"}}),
                new Question(new CreateQuestionDto {Tags = new[] {"z"}}),
            };
            _questionRepositoryMock
                .Setup(x => x.GetAllForDate(dateTime))
                .ReturnsAsync(questions);

            // Act
            DaySummaryDto daySummaryDto = await _daySummaryService.GetSummaryAsync(dateTime);

            // Assert
            Assert.That(daySummaryDto.UniqueTags.Count(), Is.EqualTo(5));
        }
    }
}