using NUnit.Framework;

namespace CrowdCat.TechnicalTest.ConsoleApp.UnitTests
{
    [TestFixture]
    public class TagFormatterTests
    {
        private TagFormatter _tagFormatter;

        [SetUp]
        public void Setup()
        {
            _tagFormatter = new TagFormatter();
        }

        [Test]
        public void GivenNonUniqueTags_WhenIFormat_ThenDistinctTagsAreReturned()
        {
            // Arrange
            string tag = "same";
            string[] strings = {tag, tag, "new"};

            // Act
            string format = _tagFormatter.Format(strings);

            // Assert
            Assert.That(format, Is.Not.Null);
            int firstIndexOf = format.IndexOf(tag);
            int lastIndexOf = format.LastIndexOf(tag);

            // If first and last match, then there is only one occurence
            Assert.That(firstIndexOf, Is.EqualTo(lastIndexOf));
        }
    }
}