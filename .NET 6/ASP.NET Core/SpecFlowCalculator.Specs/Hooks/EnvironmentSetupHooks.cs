using TechTalk.SpecFlow;

namespace SpecFlowCalculator.Specs.Hooks
{
    [Binding]
    public sealed class EnvironmentSetupHooks
    {
        public EnvironmentSetupHooks()
        {
            
        }

        [BeforeScenario(Order = 0)]
        public void BeforeScenario()
        {
        }

        [AfterScenario(Order = 0)]
        public void AfterScenario()
        {
        }
    }
}
