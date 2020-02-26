using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CrowdCat.TechnicalTest.ConsoleApp.Tests
{
    [Binding]
    public class ConsoleSteps
    {
        private readonly ConsoleDriver _consoleDriver;

        public ConsoleSteps(ConsoleDriver consoleDriver)
        {
            _consoleDriver = consoleDriver ?? throw new ArgumentNullException(nameof(consoleDriver));
        }

        [Given(@"I have the date ""(.*)""")]
        public void GivenIHaveTheDate(DateTime dateTime) =>
            _consoleDriver.DateTimeUtc = new DateTime(dateTime.Ticks, DateTimeKind.Utc);

        [When(@"I start the console application")]
        public void WhenIStartTheConsoleApplication() => _consoleDriver.Run();

        [Then(@"I should see the total number of questions")]
        public void ThenIShouldSeeTheTotalNumberOfQuestions()
        {
            string consoleOutput = _consoleDriver.Output;
            Assert.That(consoleOutput, Contains.Substring("Hello"));
        }
    }
}