using System;
using System.IO;
using BookShop.AcceptanceTests.Drivers.Selenium;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Support
{
    [Binding]
    class Screenshots
    {
        private readonly BrowserDriver _browserDriver;
        private readonly ConfigurationDriver _configurationDriver;

        public Screenshots(BrowserDriver browserDriver, ConfigurationDriver configurationDriver)
        {
            _browserDriver = browserDriver;
            _configurationDriver = configurationDriver;
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
                var tempFileName = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".png";
                screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Png);

                Console.WriteLine($"SCREENSHOT[ {tempFileName} ]SCREENSHOT");
            }
        }
    }
}
