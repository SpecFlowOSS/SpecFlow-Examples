using TechTalk.SpecFlow;
using Xunit;


namespace ScenarioFeatureContextInjection.Bindings
{
    [Binding]
    public class Bindings
    {
        private readonly ScenarioContext _scenarioContext;

        public Bindings(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            _scenarioContext["Number1"] = number;
        }

        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int number)
        {
            _scenarioContext["Number2"] = number;
        }


        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _scenarioContext["Result"] = (int)_scenarioContext["Number1"] + (int)_scenarioContext["Number2"];
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int number)
        {
            Assert.Equal(_scenarioContext["Result"], number);
        }

    }
}