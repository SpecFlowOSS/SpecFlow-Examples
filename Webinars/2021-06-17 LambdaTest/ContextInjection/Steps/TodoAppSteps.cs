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
    public sealed class TodoApp
    {
        private IWebDriver _driver;
        private LambdaTestDriver LTDriver;
        String itemName = "MI";
        String test_url = "https://lambdatest.github.io/sample-todo-app/";

        /*public TodoApp(ScenarioContext ScenarioContext)
        {
            Console.WriteLine("ToDoApp");
            if (ScenarioContext == null) throw new ArgumentNullException("ScenarioContext");
            Console.WriteLine("************************");
            Console.WriteLine(ScenarioContext.ToString());
            Console.WriteLine("************************");
            LTDriver = (LambdaTestDriver)ScenarioContext["LTDriver"];
        }
        */

        public TodoApp(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"that I am on the LambdaTest Sample app (.*) and (.*)")]
        public void GivenThatIAmOnTheLambdaTestSampleAppAnd(string profile, string environment)
        {
            Console.WriteLine("GivenThatIAmOnTheLambdaTestSampleAppAnd");
            /* _driver = LTDriver.Init(profile, environment); */
            _driver.Url = test_url;
            _driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000);
        }

        [Then(@"select the first item")]
        public void ThenSelectTheFirstItem()
        {
            Console.WriteLine("ThenSelectTheFirstItem");
            // Click on First Check box
            _driver.FindElement(By.Name("li1")).Click();
        }

        [Then(@"select the second item")]
        public void ThenSelectTheSecondItem()
        {
            // Click on Second Check box
            IWebElement secondCheckBox = _driver.FindElement(By.Name("li2"));
            secondCheckBox.Click();
        }

        [Then(@"find the text box to enter the new value")]
        public void ThenFindTheTextBoxToEnterTheNewValue()
        {
            // Enter Item name
            IWebElement textfield = _driver.FindElement(By.Id("sampletodotext"));
            textfield.SendKeys(itemName);
        }

        [Then(@"click the Submit button")]
        public void ThenClickTheSubmitButton()
        {
            // Click on Add button
            IWebElement addButton = _driver.FindElement(By.Id("addbutton"));
            addButton.Click();
        }

        [Then(@"verify whether the item is added to the list")]
        public void ThenVerifyWhetherTheItemIsAddedToTheList()
        {
            // Verified Added Item name
            IWebElement itemtext = _driver.FindElement(By.XPath("/html/body/div/div/div/form/input[1]"));
            String getText = itemtext.Text;

            // Check if the newly added item is present or not using
            // Condition constraint (Boolean)
            Assert.That((itemName.Contains(getText)), Is.True);

            /* Perform wait to check the output */
            System.Threading.Thread.Sleep(2000);

            Console.WriteLine("Firefox - Test Passed");
        }

        [Then(@"close the browser instance")]
        public void ThenCloseTheBrowserInstance()
        {
            _driver.Quit();
            Console.WriteLine("Close Done");
        }
    }
}