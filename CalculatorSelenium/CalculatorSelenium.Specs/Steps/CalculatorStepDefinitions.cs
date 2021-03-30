using System.Threading;
using CalculatorSelenium.Specs.Drivers;
using CalculatorSelenium.Specs.PageObjects;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace CalculatorSelenium.Specs.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly BrowserDriver _browserDriver;

        public CalculatorStepDefinitions(ScenarioContext scenarioContext, BrowserDriver browserDriver)
        {
            _scenarioContext = scenarioContext;
            _browserDriver = browserDriver;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            var po = new CalculatorPageObject(_browserDriver.Current);
            po.EnterFirstNumber(number.ToString());
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            var po = new CalculatorPageObject(_browserDriver.Current);
            po.EnterSecondNumber(number.ToString());
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            var po = new CalculatorPageObject(_browserDriver.Current);
            po.Add();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            var po = new CalculatorPageObject(_browserDriver.Current);

            Thread.Sleep(2000);

            var actualResult = po.GetResult();

            actualResult.Should().Be(expectedResult.ToString());
        }
    }
}
