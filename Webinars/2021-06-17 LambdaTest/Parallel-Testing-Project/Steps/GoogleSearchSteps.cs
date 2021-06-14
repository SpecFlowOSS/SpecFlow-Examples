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
    public sealed class GoogleSearch
    {
        private IWebDriver _driver;
        private LambdaTestDriver LTDriver = null;

        String test_url = "https://www.google.com/";

        public GoogleSearch(ScenarioContext ScenarioContext)
        {
            LTDriver = (LambdaTestDriver)ScenarioContext["LTDriver"];
        }

        [Given(@"that I am on the Google app (.*) and (.*)")]
        public void GivenThatIAmOnTheGoogleAppAnd(string profile, string environment)
        {
            _driver = LTDriver.Init(profile, environment);
            _driver.Url = test_url;
            _driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000);
        }

        [Then(@"click on the text box")]
        public void ThenClickOnTheTextBox()
        {
            _driver.FindElement(By.XPath("//input[@name='q']")).Click();
        }

        [Then(@"search for LambdaTest")]
        public void ThenSearchForLambdaTest()
        {
            IWebElement secondCheckBox = _driver.FindElement(By.XPath("//input[@name='q']"));
            secondCheckBox.SendKeys("LambdaTest" + Keys.Enter);
            System.Threading.Thread.Sleep(2000);
        }

        [Then(@"click on the first result")]
        public void ThenClickOnTheFirstResult()
        {
            IWebElement secondCheckBox = _driver.FindElement(By.XPath("//span[.='LambdaTest: Most Powerful Cross Browser Testing Tool Online']"));
            secondCheckBox.Click();
            System.Threading.Thread.Sleep(2000);
        }

        [Then(@"close browser")]
        public void ThenCloseBrowser()
        {
            _driver.Close();
        }
    }
}