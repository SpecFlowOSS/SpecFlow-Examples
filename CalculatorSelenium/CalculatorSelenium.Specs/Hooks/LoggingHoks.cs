using CalculatorSelenium.Specs.Drivers;
using OpenQA.Selenium.Support.Extensions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace CalculatorSelenium.Specs.Hooks
{
    [Binding]
    public sealed class LoggingHooks
    {
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        private readonly BrowserDriver _browserDriver;
        private readonly BlobLogger _blobLogger;

        public LoggingHooks(ISpecFlowOutputHelper specFlowOutputHelper, 
            BrowserDriver browserDriver,
            BlobLogger blobLogger)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
            _browserDriver = browserDriver;
            _blobLogger = blobLogger;
        }

        [AfterStep]
        public void BeforeScenario()
        {
            var screenshot = _browserDriver.Current.TakeScreenshot();
            var uri = _blobLogger.LogImage(screenshot.AsByteArray).Result;
            if (uri != null)
                _specFlowOutputHelper.AddAttachment(uri.ToString());
        }
    }
}
