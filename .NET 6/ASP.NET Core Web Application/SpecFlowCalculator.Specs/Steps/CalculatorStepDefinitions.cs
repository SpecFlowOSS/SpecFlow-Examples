using FluentAssertions;
using SpecFlowCalculator.Specs.PageObjects;
using TechTalk.SpecFlow;

namespace SpecFlowCalculator.Specs.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly CalculatorPage _calculatorPage;

        public CalculatorStepDefinitions(CalculatorPage calculatorPage)
        {
            _calculatorPage = calculatorPage;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(string number)
        {
            _calculatorPage.EnterFirstNumber(number);
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(string number)
        {
            _calculatorPage.EnterSecondNumber(number);
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _calculatorPage.ClickAdd();
        }

        [When("the two numbers are subtracted")]
        public void WhenTheTwoNumbersAreSubtracted()
        {
            _calculatorPage.ClickSubtract();
        }

        [When("the two numbers are multiplied")]
        public void WhenTheTwoNumbersAreMultiplied()
        {
            _calculatorPage.ClickMultiply();
        }

        [When("the two numbers are divided")]
        public void WhenTheTwoNumbersAreDivided()
        {
            _calculatorPage.ClickDivide();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(string result)
        {
            _calculatorPage.ResultEquals(result).Should().BeTrue();
        }
    }
}
