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
        private IWebDriver _driver;
        private ScenarioContext _scenarioContext;
        private LambdaTestDriver LTDriver = null;

        public TodoAppLTSteps(ScenarioContext scenarioContext)
        {
            LTDriver = (LambdaTestDriver)scenarioContext["LTDriver"];
        }

        [Given(@"that I am on the LambdaTest Sample app at (.*)")]
        public void GivenThatIAmOnTheLambdaTestSampleApp(string test_url)
        {
            /* Test URL is https://lambdatest.github.io/sample-todo-app/" */
            _driver = LTDriver.Init();
            _driver.Url = test_url;
            _driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000);
        }

        [Then(@"select first item")]
        public void ThenSelectFirstItem()
        {
            _driver.FindElement(By.Name("li1")).Click();
        }

        [Then(@"select second item")]
        public void ThenSelectSecondItem()
        {
            // Click on Second Check box
            IWebElement secondCheckBox = _driver.FindElement(By.Name("li2"));
            secondCheckBox.Click();
        }

        [Then(@"select third item")]
        public void ThenSelectThirdItem()
        {
            // Click on Second Check box
            IWebElement secondCheckBox = _driver.FindElement(By.Name("li3"));
            secondCheckBox.Click();
            System.Threading.Thread.Sleep(5000);
        }

        [Then(@"close the browser")]
        public void ThenCloseTheBrowser()
        {
            _driver.Quit();
            Console.WriteLine("Close Done");
        }
    }
}