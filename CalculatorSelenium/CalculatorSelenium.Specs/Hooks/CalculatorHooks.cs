using CalculatorSelenium.Specs.Drivers;
using CalculatorSelenium.Specs.PageObjects;
using TechTalk.SpecFlow;

namespace CalculatorSelenium.Specs.Hooks
{
    /// <summary>
    /// Initialize the Calculator UI
    /// </summary>
    [Binding]
    public class CalculatorHooks
    {
        [BeforeScenario("Calculator")]
        public static void BeforeScenario(BrowserDriver browserDriver)
        {
            var calculatorPageObject = new CalculatorPageObject(browserDriver.Current);
            calculatorPageObject.EnsureCalculatorIsOpenAndReset();
        }
    }
}