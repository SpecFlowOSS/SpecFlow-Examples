using System;
using System.IO;
using System.Reflection;
using LivingDoc.Demo.Drivers.Selenium;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace LivingDoc.Demo.Support
{
    [Binding]
    class Screenshots
    {
        private readonly BrowserDriver _browserDriver;
        private readonly ConfigurationDriver _configurationDriver;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public Screenshots(BrowserDriver browserDriver,
            ConfigurationDriver configurationDriver,
            FeatureContext featureContext,
            ScenarioContext scenarioContext,
            ISpecFlowOutputHelper specFlowOutputHelper
            )
        {
            _browserDriver = browserDriver;
            _configurationDriver = configurationDriver;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        [AfterStep()]
        public void MakeScreenshotAfterStep()
        {
            if (_configurationDriver.Mode.ToUpper() == "INTEGRATED")
            {
                return;
            }

            if (_browserDriver.Current is ITakesScreenshot takesScreenshot)
            {
                var screenshot = takesScreenshot.GetScreenshot();
                var tempFileName = Path.Combine(Directory.GetCurrentDirectory(),
                    Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".png";
                screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Png);

                Console.WriteLine($"SCREENSHOT[ {tempFileName} ]SCREENSHOT");
            }
        }

        [AfterStep()]
        public void MakeScreenshotForOutput()
        {
            if (_scenarioContext.ScenarioInfo.Title != "Cheapest 3 books should be listed on the home screen")
            {
                return;
            }

            var title = $"{_featureContext.FeatureInfo.Title} {_scenarioContext.ScenarioInfo.Title} {_scenarioContext.StepContext.StepInfo.Text}";
            var relativePath = Path.Combine("Screenshots",
                $"{(title).Replace(" ", "_")}.png");

            _specFlowOutputHelper.AddAttachment(relativePath);

            if (_configurationDriver.Mode.ToUpper() == "INTEGRATED")
            {
                return;
            }

            if (_browserDriver.Current is ITakesScreenshot takesScreenshot)
            {
                var screenshot = takesScreenshot.GetScreenshot();
                var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                   relativePath);
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                screenshot.SaveAsFile(path);
            }

        }
    }
}
