using SpecFlowCalculator.Specs.PageObjects;
using TechTalk.SpecFlow;

namespace SpecFlowCalculator.Specs.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeScenario]
        public void BeforeScenario(CalculatorPage calculatorPage)
        {
            calculatorPage.Goto();
        }
    }
}
