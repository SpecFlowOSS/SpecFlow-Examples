using System;
using TechTalk.SpecFlow;

namespace GherkinFormattingExamples.StepDefinitions
{
    [Binding]
    public class GherkinFormattingExamplesSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public GherkinFormattingExamplesSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I need to prepare some data for my scenario")]
        public void GivenINeedToPrepareSomeDataForMyScenario()
        {
            _scenarioContext.Pending();
        }
        
        [Given(@"this is more complex so I need a second step")]
        public void GivenThisIsMoreComplexSoINeedASecondStep()
        {
            _scenarioContext.Pending();
        }
        
        [Given(@"this is more complex so I need a third step")]
        public void GivenThisIsMoreComplexSoINeedAThirdStep()
        {
            _scenarioContext.Pending();
        }

        [Given(@"I need to prepare the following data for my scenario:")]
        public void GivenINeedToPrepareTheFollowingDataForMyScenario(Table table)
        {
            _scenarioContext.Pending();
        }

        [Given(@"this is more complex so I need a second step with a table:")]
        public void GivenThisIsMoreComplexSoINeedASecondStepWithATable(Table table)
        {
            _scenarioContext.Pending();
        }

        [Given(@"this is more complex so I need a third step with a table:")]
        public void GivenThisIsMoreComplexSoINeedAThirdStepWithATable(Table table)
        {
            _scenarioContext.Pending();
        }

        [Given(@"I add a new person")]
        public void GivenIAddANewPerson()
        {
            _scenarioContext.Pending();
        }

        [Given(@"this person has the birthdate '(.*)'")]
        public void GivenThisPersonHasTheBirthdate(string p0)
        {
            _scenarioContext.Pending();
        }

        [When(@"I trigger some action")]
        public void WhenITriggerTheAction()
        {
            _scenarioContext.Pending();
        }

        [When(@"I try to save this person")]
        public void WhenITryToSaveThisPerson()
        {
            _scenarioContext.Pending();
        }

        [Then(@"I can see the expected outcome")]
        public void ThenICanSeeTheExpectedOutcome()
        {
            _scenarioContext.Pending();
        }

        [Then(@"this outcome also has a second step")]
        public void ThenThisOutcomeAlsoHasASecondStep()
        {
            _scenarioContext.Pending();
        }

        [Then(@"this outcome also has a third step")]
        public void ThenThisOutcomeAlsoHasAThirdStep()
        {
            _scenarioContext.Pending();
        }

        [Then(@"I receive the error message for '(.*)'")]
        public void ThenIReceiveTheErrorMessageFor(string p0)
        {
            _scenarioContext.Pending();
        }


    }
}
