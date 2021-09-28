using System.Threading.Tasks;
using FluentAssertions;
using SpecFlowCalculator.Specs.API;
using TechTalk.SpecFlow;

namespace SpecFlowCalculator.Specs.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly CalculatorApi _calculator;
        private int _result;

        public CalculatorStepDefinitions(CalculatorApi calculator)
        {
            _calculator = calculator;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _calculator.FirstNumber = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _calculator.SecondNumber = number;
        }

        [When("the two numbers are added")]
        public async Task WhenTheTwoNumbersAreAddedAsync()
        {
            _result = await _calculator.AddAsync();
        }

        [When(@"the two numbers are subtracted")]
        public async Task WhenTheTwoNumbersAreSubtractedAsync()
        {
            _result = await _calculator.SubtractAsync();
        }

        [When(@"the two numbers are divided")]
        public async Task WhenTheTwoNumbersAreDividedAsync()
        {
            _result = await _calculator.DivideAsync();
        }

        [When(@"the two numbers are multiplied")]
        public async Task WhenTheTwoNumbersAreMultiplied()
        {
            _result = await _calculator.MultiplyAsync();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            _result.Should().Be(result);
        }
    }
}