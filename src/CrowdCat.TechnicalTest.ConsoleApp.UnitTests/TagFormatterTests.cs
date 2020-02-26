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

        [Test]
        public void GivenVariousTags_WhenIFormat_ThenTheyAreReturnedInAlphabeticalOrder()
        {
            // Arrange
            string[] strings = {"d", "b", "c", "a"};

            // Act
            string format = _tagFormatter.Format(strings);

            // Assert
            Assert.That(format, Is.Not.Null);
            int indexOfA = format.IndexOf("a");
            int indexOfB = format.IndexOf("b");
            int indexOfC = format.IndexOf("c");
            int indexOfD = format.IndexOf("d");
 
            // If first and last match, then there is only one occurence
            Assert.That(indexOfA, Is.LessThan(indexOfB));
            Assert.That(indexOfB, Is.LessThan(indexOfC));
            Assert.That(indexOfC, Is.LessThan(indexOfD));
        }
    }
}