using System;
using System.Threading.Tasks;
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
        public void GivenIHaveTheDate(string date) => _consoleDriver.DateInputParameter = date;

        [When(@"I start the console application")]
        public async Task WhenIStartTheConsoleApplication() => await _consoleDriver.Run();

        [Then(@"I should see the total number of questions")]
        public void ThenIShouldSeeTheTotalNumberOfQuestions()
        {
            Assert.That(_consoleDriver.Output, Contains.Substring("Total questions: 5"));
        }

        [Then(@"I should see the total of view counts")]
        public void ThenIShouldSeeTheTotalOfViewCounts()
        {
            Assert.That(_consoleDriver.Output, Contains.Substring("Total views: 109"));
        }
        
        [Then(@"I should see the tags in distinct alphabetical order")]
        public void ThenIShouldSeeTheTagsInDistinctAlphabeticalOrder()
        {
            Assert.That(_consoleDriver.Output, Contains.Substring("a,b,d,z"));
        }
    }
}