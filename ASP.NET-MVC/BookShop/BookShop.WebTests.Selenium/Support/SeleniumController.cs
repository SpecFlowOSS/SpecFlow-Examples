using System;
using System.Configuration;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace BookShop.WebTests.Selenium.Support
{
    public class SeleniumController
    {
        public static SeleniumController Instance = new SeleniumController();

        public IWebDriver Selenium { get; private set; }

        private void Trace(string message)
        {
            Console.WriteLine("-> {0}", message);
        }

        public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);

        public void Start()
        {
            if (Selenium != null)
                return;

            var appUrl = ConfigurationManager.AppSettings["AppUrl"];

            Selenium = new FirefoxDriver();
            // Selenium = new InternetExplorerDriver();
            Selenium.Manage().Timeouts().ImplicitlyWait(DefaultTimeout);

//            Selenium = new DefaultSelenium("localhost", 4444, "*chrome", appUrl);
//            Selenium.Start();
            Trace("Selenium started");
        }

        public void Stop()
        {
            if (Selenium == null)
                return;

            try
            {
                Selenium.Quit();
                Selenium.Dispose();

                //Selenium.Stop();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex, "Selenium stop error");
            }
            Selenium = null;
            Trace("Selenium stopped");
        }
    }
}