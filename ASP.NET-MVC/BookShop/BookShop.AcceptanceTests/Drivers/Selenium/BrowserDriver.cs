using System;
using BookShop.AcceptanceTests.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BookShop.AcceptanceTests.Drivers.Selenium
{
    public class BrowserDriver : IDisposable
    {
        private readonly BrowserSeleniumDriverFactory _browserSeleniumDriverFactory;
        private readonly ConfigurationDriver _configurationDriver;
        private readonly WebServerDriver _webServerDriver;
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private readonly Lazy<WebDriverWait> _waitLazy;
        private readonly TimeSpan _waitDuration = TimeSpan.FromSeconds(10);
        private bool _isDisposed;

        public BrowserDriver(BrowserSeleniumDriverFactory browserSeleniumDriverFactory, ConfigurationDriver configurationDriver, WebServerDriver webServerDriver)
        {
            _browserSeleniumDriverFactory = browserSeleniumDriverFactory;
            _configurationDriver = configurationDriver;
            _webServerDriver = webServerDriver;
            _currentWebDriverLazy = new Lazy<IWebDriver>(GetWebDriver);
            _waitLazy = new Lazy<WebDriverWait>(GetWebDriverWait);
        }

        public IWebDriver Current => _currentWebDriverLazy.Value;

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

        public void Navigate(string urlPart)
        {
            if (!Current.Url.EndsWith(urlPart))
            {
                Current.Navigate().GoToUrl($"{_webServerDriver.Hostname}/{urlPart}");
                RetryHelper.WaitFor(() => Current.Url.EndsWith(urlPart));
            }
        }
    }
}