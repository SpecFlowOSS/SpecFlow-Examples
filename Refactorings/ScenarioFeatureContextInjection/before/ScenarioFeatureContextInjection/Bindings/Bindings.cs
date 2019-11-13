using TechTalk.SpecFlow;
using Xunit;


namespace ScenarioFeatureContextInjection.Bindings
{
    [Binding]
    public class Bindings
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            ScenarioContext.Current["Number1"] = number;
        }

        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int number)
        {
            ScenarioContext.Current["Number2"] = number;
        }


        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            ScenarioContext.Current["Result"] = (int)ScenarioContext.Current["Number1"] + (int)ScenarioContext.Current["Number2"];
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int number)
        {
            Assert.Equal(ScenarioContext.Current["Result"], number);
        }

    }
}