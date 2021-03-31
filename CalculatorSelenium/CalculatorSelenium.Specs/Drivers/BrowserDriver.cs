using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CalculatorSelenium.Specs.Drivers
{
    public class BrowserDriver : IDisposable
    {
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;

        public BrowserDriver()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(GetWebDriver);
        }

        public IWebDriver Current => _currentWebDriverLazy.Value;

        private IWebDriver GetWebDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();

            var chromeOptions = new ChromeOptions();

            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions)
            {
                Url = "https://specflowoss.github.io/Calculator-Demo/Calculator.html"
            };

            return chromeDriver;
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
}