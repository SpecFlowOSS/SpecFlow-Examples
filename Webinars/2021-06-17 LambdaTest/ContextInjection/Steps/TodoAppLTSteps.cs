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
/* For using Remote Selenium WebDriver */
using OpenQA.Selenium.Remote;

namespace SpecFlowParallel
{
    [Binding]
    public sealed class TodoAppLTSteps
    {
        String itemName = "MI";
        String test_url = "https://lambdatest.github.io/sample-todo-app/";
        private WebDriverContext _webDriverContext;

        public TodoAppLTSteps(WebDriverContext webDriverContext)
        {
            this._webDriverContext = webDriverContext;
        }

        [Given(@"that I am on the LambdaTest Sample app")]
        public void GivenThatIAmOnTheLambdaTestSampleApp()
        {

            _webDriverContext.webdriver.Url = test_url;
            _webDriverContext.webdriver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000);
        }


        [Given(@"that I am on the LambdaTest Sample app (.*), (.*), (.*) and (.*)")]
        public void GivenThatIAmOnTheLambdaTestSampleAppAnd(string profile, string environment, string version, string platform)
        {
            _webDriverContext.webdriver.Url = test_url;
            _webDriverContext.webdriver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000);
        }

        [Then(@"select first item")]
        public void ThenSelectFirstItem()
        {
            Console.WriteLine("ThenSelectTheFirstItem");
            // Click on First Check box
            _webDriverContext.webdriver.FindElement(By.Name("li1")).Click();
        }

        [Then(@"select second item")]
        public void ThenSelectSecondItem()
        {
            // Click on Second Check box
            IWebElement secondCheckBox = _webDriverContext.webdriver.FindElement(By.Name("li2"));
            secondCheckBox.Click();
        }

        [Then(@"select third item")]
        public void ThenSelectThirdItem()
        {
            // Click on Second Check box
            IWebElement secondCheckBox = _webDriverContext.webdriver.FindElement(By.Name("li3"));
            secondCheckBox.Click();
            System.Threading.Thread.Sleep(5000);
        }

        [Then(@"close the browser")]
        public void ThenCloseTheBrowser()
        {
            _webDriverContext.webdriver.Quit();
            Console.WriteLine("Close Done");
        }
    }
}