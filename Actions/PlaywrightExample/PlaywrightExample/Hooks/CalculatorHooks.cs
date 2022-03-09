using Example.PageObjects;
using Microsoft.Playwright;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Example.Hooks
{
    /// <summary>
    /// Calculator related hooks
    /// </summary>
    [Binding]
    public class CalculatorHooks
    {
        private readonly string _traceName;

        public CalculatorHooks(ScenarioContext scenarioContext)
        {
            _traceName = scenarioContext.ScenarioInfo.Title.Replace(" ", "_");
        }

        ///<summary>
        ///  Reset the calculator before each scenario tagged with "Calculator"
        /// </summary>
        [BeforeScenario("Calculator")]
        public async void BeforeScenarioAsync(CalculatorPageObject calculatorPageObject)
        {
            await calculatorPageObject.EnsureCalculatorIsOpenAndResetAsync();
        }
        
        [BeforeScenario]
        public async Task StartTracingAsync(CalculatorPageObject calculatorPageObject)
        {
            var tracing = await calculatorPageObject.Tracing;
            await tracing.StartAsync(new TracingStartOptions
            {
                Name = _traceName,
                Screenshots = true,
                Snapshots = true
            });
        }

        [AfterScenario]
        public async Task StopTracingAsync(CalculatorPageObject calculatorPageObject)
        {
            var tracing = await calculatorPageObject.Tracing;
            await tracing.StopAsync(new TracingStopOptions()
            {
                Path = $"traces/{_traceName}.zip"
            });
        }

    }
}