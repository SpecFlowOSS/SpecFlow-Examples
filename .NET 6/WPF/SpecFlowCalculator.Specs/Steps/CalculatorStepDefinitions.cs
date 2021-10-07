using FluentAssertions;
using SpecFlowCalculator.Specs.CalculatorApp;
using TechTalk.SpecFlow;

namespace SpecFlowCalculator.Specs.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly CalculatorForm _calculatorForm;

        public CalculatorStepDefinitions(CalculatorForm calculatorForm)
        {
            _calculatorForm = calculatorForm;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _calculatorForm.EnterFirstNumber(number.ToString());
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _calculatorForm.EnterSecondNumber(number.ToString());
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _calculatorForm.ClickAdd();
        }

        [When(@"the two numbers are subtracted")]
        public void WhenTheTwoNumbersAreSubtracted()
        {
            _calculatorForm.ClickSubtract();
        }

        [When(@"the two numbers are multiplied")]
        public void WhenTheTwoNumbersAreMultiplied()
        {
            _calculatorForm.ClickMultiply();
        }

        [When(@"the two numbers are divided")]
        public void WhenTheTwoNumbersAreDivided()
        {
            _calculatorForm.ClickDivide();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            var actualResult = int.Parse(_calculatorForm.GetResult());

            result.Should().Be(actualResult);
        }
    }
}