using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace BookShop.AcceptanceTests.WatiN.Support
{
    static public class WatiNStepsExtensions
    {
        public static void GoToThePage(this Browser browser, string page)
        {
            var rootUrl = new Uri(ConfigurationManager.AppSettings["AppUrl"]);
            var absoluteUrl = new Uri(rootUrl, page);
            browser.GoTo(absoluteUrl);
            //browser.WaitForComplete();
            //Thread.Sleep(500);
        }
    }
}
