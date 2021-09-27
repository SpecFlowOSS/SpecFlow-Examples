using SpecFlowCalculator.Specs.PageObjects;
using TechTalk.SpecFlow;

namespace SpecFlowCalculator.Specs.Hooks
{
    [Binding]
    public sealed class TestExecutionHooks
    {
        [BeforeScenario]
        public void BeforeScenario(CalculatorPage calculatorPage)
        {
            calculatorPage.Goto();
        }
    }
}
