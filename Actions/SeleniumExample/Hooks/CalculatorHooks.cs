using Example.PageObjects;
using SpecFlow.Actions.Selenium;
using TechTalk.SpecFlow;

namespace Example.Hooks
{
    /// <summary>
    /// Calculator related hooks
    /// </summary>
    [Binding]
    public class CalculatorHooks
    {
        private readonly IBrowserInteractions _browserInteractions;

        public CalculatorHooks(IBrowserInteractions browserInteractions)
        {
            _browserInteractions = browserInteractions;
        }

        ///<summary>
        ///  Reset the calculator before each scenario tagged with "Calculator"
        /// </summary>
        [BeforeScenario("Calculator")]
        public void BeforeScenario()
        {
            var calculatorPageObject = new CalculatorPageObject(_browserInteractions);
            calculatorPageObject.EnsureCalculatorIsOpenAndReset();
        }
    }
}