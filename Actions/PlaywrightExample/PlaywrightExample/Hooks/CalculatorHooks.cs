using Example.PageObjects;
using Microsoft.Playwright;
using System.Threading.Tasks;
using SpecFlow.Actions.Playwright;
using TechTalk.SpecFlow;

namespace Example.Hooks
{
    /// <summary>
    /// Calculator related hooks
    /// </summary>
    [Binding]
    public class CalculatorHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly string _traceName;

        public CalculatorHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _traceName = scenarioContext.ScenarioInfo.Title.Replace(" ", "_");
        }

        ///<summary>
        ///  Reset the calculator before each scenario tagged with "Calculator"
        /// </summary>
        [BeforeScenario(Order = 0)]
        public async Task BeforeScenarioAsync(BrowserDriver browserDriver)
        {
            var calculatorPageObjectPage = await (await browserDriver.Current).NewPageAsync();

            var calculatorPageObject = new CalculatorPageObject(calculatorPageObjectPage);

            await calculatorPageObject.EnsureCalculatorIsOpenAndResetAsync();


            _scenarioContext.ScenarioContainer.RegisterInstanceAs(calculatorPageObject);
            
        }
        
        //[BeforeScenario(Order = 1000)]
        //public async Task StartTracingAsync(CalculatorPageObject calculatorPageObject)
        //{
        //    var tracing = calculatorPageObject.Page.Context.Tracing;
        //    await tracing.StartAsync(new TracingStartOptions
        //    {
        //        Name = _traceName,
        //        Screenshots = true,
        //        Snapshots = true
        //    });
        //}

        //[AfterScenario]
        //public async Task StopTracingAsync(CalculatorPageObject calculatorPageObject)
        //{
        //    var tracing = calculatorPageObject.Page.Context.Tracing;
        //    await tracing.StopAsync(new TracingStopOptions()
        //    {
        //        Path = $"traces/{_traceName}.zip"
        //    });
        //}

    }
}