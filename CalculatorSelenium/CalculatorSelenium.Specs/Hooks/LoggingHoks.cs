using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        public LoggingHooks(ISpecFlowOutputHelper specFlowOutputHelper, BrowserDriver browserDriver)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
            _browserDriver = browserDriver;
        }

        [AfterStep()]
        public void BeforeScenario()
        {
            var screenshot = _browserDriver.Current.TakeScreenshot();
            var imagePath = Path.GetTempFileName();
            screenshot.SaveAsFile(imagePath);
            _specFlowOutputHelper.AddAttachment(imagePath);
        }

        [AfterScenario]
        public void AfterScenario()
        {
        }
    }
}
