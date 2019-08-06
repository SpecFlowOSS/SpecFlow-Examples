using System.Configuration;
using System.Text;
using TechTalk.SpecFlow;

namespace BookShop.WebTests.Selenium.Support
{
    [Binding]
    public static class SeleniumSupport
    {

        private static bool ReuseWebSession
        {
            get { return ConfigurationManager.AppSettings["ReuseWebSession"] == "true"; }
        }

        [BeforeScenario("web")]
        public static void BeforeWebScenario(SeleniumController seleniumController)
        {
            seleniumController.Start();
        }

        [AfterScenario("web")]
        public static void AfterWebScenario(SeleniumController seleniumController)
        {
            if (!ReuseWebSession)
                seleniumController.Stop();
        }

        //[AfterFeature]
        [AfterTestRun]
        public static void AfterWebFeature(SeleniumController seleniumController)
        {
            seleniumController.Stop();
        }
    }
}