using System;
using TechTalk.SpecFlow;

namespace GherkinFormattingExamples.StepDefinitions
{
    [Binding]
    public class GherkinFormattingExamplesSteps
    {
        [Given(@"I need to prepare some data for my scenario")]
        public void GivenINeedToPrepareSomeDataForMyScenario()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"this is more complex so I need a second step")]
        public void GivenThisIsMoreComplexSoINeedASecondStep()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"this is more complex so I need a third step")]
        public void GivenThisIsMoreComplexSoINeedAThirdStep()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I trigger some action")]
        public void WhenITriggerTheAction()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I can see the expected outcome")]
        public void ThenICanSeeTheExpectedOutcome()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"this outcome also has a second step")]
        public void ThenThisOutcomeAlsoHasASecondStep()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"this outcome also has a third step")]
        public void ThenThisOutcomeAlsoHasAThirdStep()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I need to prepare the following data for my scenario:")]
        public void GivenINeedToPrepareTheFollowingDataForMyScenario(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"this is more complex so I need a second step with a table:")]
        public void GivenThisIsMoreComplexSoINeedASecondStepWithATable(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"this is more complex so I need a third step with a table:")]
        public void GivenThisIsMoreComplexSoINeedAThirdStepWithATable(Table table)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
