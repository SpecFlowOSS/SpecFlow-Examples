namespace VerifyExample.StepDefinitions
{
    [Binding]
    public sealed class VerifyStepDefinitions
    {
        [Given(@"the user prepared something")]
        public void GivenTheUserPreparedSomething()
        {
            
        }

        [When(@"the user does something")]
        public void WhenTheUserDoesSomething()
        {
            
        }

        [Then(@"the result is verified")]
        public async Task ThenTheResultIsVerified()
        {
            await Verify("result");
        }

    }
}