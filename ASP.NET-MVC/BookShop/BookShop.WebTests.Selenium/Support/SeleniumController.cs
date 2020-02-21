using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
////using OpenQA.WebDriver.Firefox;
////using OpenQA.WebDriver.IE;

namespace BookShop.WebTests.Selenium.Support
{
    public class SeleniumController : IDisposable
    {
        public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);

        public IWebDriver WebDriver { get; private set; }

        public void Start()
        {
            if (!(WebDriver is null))
            {
                return;
            }

            ////WebDriver = new FirefoxDriver();
            ////WebDriver = new InternetExplorerDriver();
            WebDriver = new ChromeDriver();
            WebDriver.Manage().Timeouts().ImplicitWait = DefaultTimeout;

            ////WebDriver = new DefaultSelenium("localhost", 4444, "*chrome", appUrl);
            ////WebDriver.Start();
            Trace("WebDriver started");
        }

        public void Stop()
        {
            if (WebDriver is null)
            {
                return;
            }

            try
            {
                WebDriver.Quit();
                WebDriver.Dispose();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc, "WebDriver stop error");
            }

            WebDriver = null;
            Trace("WebDriver stopped");
        }

        private static void Trace(string message) => Console.WriteLine($"-> {message}");

        public void Dispose()
        {
            if (WebDriver is null)
            {
                return;
            }

            try
            {
                WebDriver.Quit();
                WebDriver.Dispose();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc, "WebDriver stop error");
            }

            WebDriver = null;

            Trace("WebDriver stopped");
        }
    }
}