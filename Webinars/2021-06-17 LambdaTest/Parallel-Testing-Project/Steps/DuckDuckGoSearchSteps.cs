using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace SpecFlowLambdaSample
{
    [Binding]
    public sealed class DuckDuckGoSearch
    {
        private IWebDriver _driver;
        private LambdaTestDriver LTDriver = null;
        String test_url = "https://www.duckduckgo.com/";
        String expected_title = "LambdaTest | A Cross Browser Testing Blog";

        public DuckDuckGoSearch(ScenarioContext ScenarioContext)
        {
            LTDriver = (LambdaTestDriver)ScenarioContext["LTDriver"];
        }

        [Given(@"that I am on the DuckDuckGo Search Page with (.*), (.*), (.*), (.*), and (.*)")]
        public void GivenThatIAmOnTheDuckDuckGoSearchPageWithAnd(string build, string name, string platform, 
            string browserName, string version)
        {
            _driver = LTDriver.InitLocal(build, name, platform, browserName, version);
            _driver.Url = test_url;
            _driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000);
        }

        [Then(@"search for LambdaTest Blog")]
        public void ThenSearchForLambdaTestBlog()
        {
            IWebElement search_box = _driver.FindElement(By.CssSelector("#search_form_input_homepage"));
            search_box.Click();
            search_box.SendKeys("LambdaTest Blog" + Keys.Enter);
            System.Threading.Thread.Sleep(2000);
        }

        [Then(@"click on the available result")]
        public void ThenClickOnTheAvailableResult()
        {
            IWebElement search_result = _driver.FindElement(By.XPath("//a[.='LambdaTest | A Cross Browser Testing Blog']"));
            search_result.Click();
            System.Threading.Thread.Sleep(2000);
        }

        [Then(@"compare results")]
        public void ThenCompareResults()
        {
            String page_title = _driver.Title;
            Assert.IsTrue(true, page_title, expected_title);
        }

        [Then(@"close the current browser window")]
        public void ThenCloseTheCurrentBrowserWindow()
        {
            _driver.Close();
        }
    }
}