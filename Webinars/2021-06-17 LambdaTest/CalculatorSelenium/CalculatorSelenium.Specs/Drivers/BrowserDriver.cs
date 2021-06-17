using System;
using System.Collections;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
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
        private readonly TargetConfiguration _targetConfiguration;
        private readonly ScenarioContext _scenarioContext;
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;

        public BrowserDriver(TestRunContext testRunContext, LambdaTestCredentials lambdaTestCredentials, TargetConfiguration targetConfiguration,
            ScenarioContext scenarioContext)
        {
            _testRunContext = testRunContext;
            _lambdaTestCredentials = lambdaTestCredentials;
            _targetConfiguration = targetConfiguration;
            _scenarioContext = scenarioContext;
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
            if (String.IsNullOrWhiteSpace(_targetConfiguration.Browser))
            {
                var chromeDriverService = ChromeDriverService.CreateDefaultService(_testRunContext.TestDirectory);

                var chromeOptions = new ChromeOptions();


                var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);

                return chromeDriver;
            }


            DesiredCapabilities capability = new DesiredCapabilities();

            capability.SetCapability("username", _lambdaTestCredentials.Username);
            capability.SetCapability("accesskey", _lambdaTestCredentials.Accesskey);
            capability.SetCapability("build", "Calculator " + _targetConfiguration.Name);
            var testName = _scenarioContext.ScenarioInfo.Title;

            if (_scenarioContext.ScenarioInfo.Arguments.Count > 0)
            {
                testName += ": ";
            }

            foreach (DictionaryEntry argument in _scenarioContext.ScenarioInfo.Arguments)
            {
                testName += argument.Key + ":" + argument.Value + "; ";
            }

            testName = testName.Trim();

            capability.SetCapability("name", testName);
            capability.SetCapability("idleTimeout", "270");

            capability.SetCapability("browserName", _targetConfiguration.Browser);
            capability.SetCapability("platformName", _targetConfiguration.OperatingSystem);


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