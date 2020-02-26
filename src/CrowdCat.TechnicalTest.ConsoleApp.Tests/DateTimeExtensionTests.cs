using System;
using NUnit.Framework;

namespace CrowdCat.TechnicalTest.ConsoleApp.Tests
{
    [TestFixture]
    public class DateTimeExtensionTests
    {
        [Test]
        public void GivenDateTime_WhenIConvertToUnixTimestamp_ThenItIsConverted()
        {
            // Arrange
            DateTime dateTime = new DateTime(2019, 01, 01, 14, 00, 00);

            // Act
            double unixTimestamp = dateTime.ToUnixTimestamp();

            // Assert
            double expectedUnixTimestamp = 1546351200;
            Assert.That(unixTimestamp, Is.EqualTo(expectedUnixTimestamp));
        }
    }
}