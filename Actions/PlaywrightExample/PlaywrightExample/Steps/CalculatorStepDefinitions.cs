using Example.PageObjects;
using FluentAssertions;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Example.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        //Page Object for Calculator
        private readonly CalculatorPageObject _calculatorPageObject;

        public CalculatorStepDefinitions(CalculatorPageObject calculatorPageObject)
        {
            _calculatorPageObject = calculatorPageObject;
        }

        [Given("the first number is (.*)")]
        public async Task GivenTheFirstNumberIsAsync(string value)
        {
            //delegate to Page Object
            await _calculatorPageObject.EnterFirstNumberAsync(value);
        }

        [Given("the second number is (.*)")]
        public async Task GivenTheSecondNumberIsAsync(string value)
        {
            //delegate to Page Object
            await _calculatorPageObject.EnterSecondNumberAsync(value);
        }

        [When("the two numbers are added")]
        public async Task WhenTheTwoNumbersAreAddedAsync()
        {
            //delegate to Page Object
            await _calculatorPageObject.ClickAddAsync();
        }

        [Then("the result should be (.*)")]
        public async Task ThenTheResultShouldBeAsync(string value)
        {
            //delegate to Page Object
            var actualResult = await _calculatorPageObject.WaitForNonEmptyResultAsync();

            actualResult.Should().Be(value);
        }
    }
}