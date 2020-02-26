using System;
using NUnit.Framework;

namespace CrowdCat.TechnicalTest.ConsoleApp.UnitTests
{
    [TestFixture]
    public class DateParserTests
    {
        private DateParser _dateParser;

        [SetUp]
        public void Setup()
        {
            _dateParser = new DateParser();
        }

        [Test]
        public void GivenDateString_WhenIParse_ThenADateTimeIsReturned()
        {
            // Arrange
            string date = "2019-04-01";

            // Act
            DateTime? dateTime = _dateParser.Parse(date);

            // Assert
            DateTime expectedDateTime = new DateTime(2019, 4, 1);
            Assert.True(dateTime.HasValue);
            Assert.That(dateTime.Value.Date, Is.EqualTo(expectedDateTime));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase("2019")]
        public void GivenInvalidDateString_WhenIParse_ThenNothingIsReturned(string date)
        {
            // Act
            DateTime? dateTime = _dateParser.Parse(date);

            // Assert
            Assert.False(dateTime.HasValue);
        }
    }
}