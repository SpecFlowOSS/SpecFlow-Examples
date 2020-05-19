using System;
using BookShop.AcceptanceTests.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecRun;

namespace BookShop.AcceptanceTests.Drivers.Selenium
{
    public class BrowserDriver : IDisposable
    {
        private readonly BrowserSeleniumDriverFactory _browserSeleniumDriverFactory;
        private readonly ConfigurationDriver _configurationDriver;
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private readonly Lazy<WebDriverWait> _waitLazy;
        private readonly TimeSpan _waitDuration = TimeSpan.FromSeconds(10);
        private bool _isDisposed;

        public WebDriver(BrowserSeleniumDriverFactory browserSeleniumDriverFactory, ConfigurationDriver configurationDriver)
        {
            _browserSeleniumDriverFactory = browserSeleniumDriverFactory;
            _configurationDriver = configurationDriver;
            _currentWebDriverLazy = new Lazy<IWebDriver>(GetWebDriver);
            _waitLazy = new Lazy<WebDriverWait>(GetWebDriverWait);
        }

        public IWebDriver Current => _currentWebDriverLazy.Value;

        public WebDriverWait Wait => _waitLazy.Value;

        private WebDriverWait GetWebDriverWait()
        {
            return new WebDriverWait(Current, _waitDuration);
        }

        private IWebDriver GetWebDriver()
        {
            
            return _browserSeleniumDriverFactory.GetForBrowser(_configurationDriver.Mode);
        }

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

    public class BrowserSeleniumDriverFactory
    {
        private readonly ConfigurationDriver _configurationDriver;
        private readonly TestRunContext _testRunContext;

        public BrowserSeleniumDriverFactory(ConfigurationDriver configurationDriver, TestRunContext testRunContext)
        {
            _configurationDriver = configurationDriver;
            _testRunContext = testRunContext;
        }

        public IWebDriver GetForBrowser(string browserId)
        {
            string lowerBrowserId = browserId.ToUpper();
            switch (lowerBrowserId)
            {
                case "IE": return GetInternetExplorerDriver();
                case "CHROME": return GetChromeDriver();
                case "FIREFOX": return GetFirefoxDriver();
                case string browser: throw new NotSupportedException($"{browser} is not a supported browser");
                default: throw new NotSupportedException("not supported browser: <null>");
            }
        }

        private IWebDriver GetFirefoxDriver()
        {
            return new FirefoxDriver(FirefoxDriverService.CreateDefaultService(_testRunContext.TestDirectory))
            {
                Url = _configurationDriver.SeleniumBaseUrl,

            };
        }

        private IWebDriver GetChromeDriver()
        {
            return new ChromeDriver(ChromeDriverService.CreateDefaultService(_testRunContext.TestDirectory))
            {
                Url = _configurationDriver.SeleniumBaseUrl
            };
        }

        private IWebDriver GetInternetExplorerDriver()
        {
            var internetExplorerOptions = new InternetExplorerOptions
            {
                IgnoreZoomLevel = true,


            };
            return new InternetExplorerDriver(InternetExplorerDriverService.CreateDefaultService(_testRunContext.TestDirectory), internetExplorerOptions)
            {
                Url = _configurationDriver.SeleniumBaseUrl,


            };
        }
    }
}