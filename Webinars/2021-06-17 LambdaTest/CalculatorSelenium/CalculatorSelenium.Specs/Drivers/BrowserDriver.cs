using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using TechTalk.SpecRun;

namespace CalculatorSelenium.Specs.Drivers
{
    /// <summary>
    /// Manages a browser instance using Selenium
    /// </summary>
    public class BrowserDriver : IDisposable
    {
        private readonly TestRunContext _testRunContext;
        private readonly LambdaTestCredentials _lambdaTestCredentials;
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;

        public BrowserDriver(TestRunContext testRunContext, LambdaTestCredentials lambdaTestCredentials)
        {
            _testRunContext = testRunContext;
            _lambdaTestCredentials = lambdaTestCredentials;
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
        }

        /// <summary>
        /// The Selenium IWebDriver instance
        /// </summary>
        public IWebDriver Current => _currentWebDriverLazy.Value;

        /// <summary>
        /// Creates the Selenium web driver (opens a browser)
        /// </summary>
        /// <returns></returns>
        private IWebDriver CreateWebDriver()
        {
            ////We use the Chrome browser
            //var chromeDriverService = ChromeDriverService.CreateDefaultService(_testRunContext.TestDirectory);

            //var chromeOptions = new ChromeOptions();


            //var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);

            //return chromeDriver;

            DesiredCapabilities capability = new DesiredCapabilities();
            

            

            capability.SetCapability("username", _lambdaTestCredentials.Username);
            capability.SetCapability("accesskey", _lambdaTestCredentials.Accesskey);
            capability.SetCapability("build", "Calculator");
            capability.SetCapability("name", "Calculator");
            capability.SetCapability("idleTimeout", "270");

            capability.SetCapability("browserName", "Chrome");
            capability.SetCapability("browserVersion", "87.0");
            capability.SetCapability("platformName", "Windows 10");


            var remoteAddress = new Uri("http://" + _lambdaTestCredentials.Username + ":" + _lambdaTestCredentials.Accesskey + "@hub.lambdatest.com" + "/wd/hub/");
            var driver = new RemoteWebDriver(remoteAddress, capability);

            return driver;
        }

        /// <summary>
        /// Disposes the Selenium web driver (closing the browser)
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }

            _isDisposed = true;
        }
    }
}