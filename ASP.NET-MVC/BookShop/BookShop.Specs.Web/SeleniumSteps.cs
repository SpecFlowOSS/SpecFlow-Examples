using System;
using BookShop.Models;
using NUnit.Framework;
using Selenium;
using TechTalk.SpecFlow;

namespace BookShop.Specs.Web
{
    [Binding]
    public class SeleniumSteps
    {
        private readonly ISelenium _selenium;

        public SeleniumSteps(SeleniumContext seleniumContext)
        {
            _selenium = seleniumContext.Selenium;
        }

        [BeforeScenario]
        public void SetupTest()
        {
            _selenium.Start();
            _selenium.GetEval("window.resizeTo(1000, 600); window.moveTo(0,0);");
//            _selenium.SetSpeed("2000");
        }

        [AfterScenario]
        public void TeardownTest()
        {
            _selenium.Stop();
        }

        [When(@"I go to the '(.*)' page")]
        public void GoToThePage(string page)
        {
            _selenium.Open("/" + page);
        }

        [When(@"I click the link '(.*)'")]
        public void ClickTheLink(string link)
        {
            _selenium.Click("link=" + link);
            _selenium.WaitForPageToLoad("30000");
        }    
        
        [When(@"I click the button '(.*)'")]
        public void ClickTheButton(string button)
        {
            _selenium.Click("//input[@value='" + button + "']");
            _selenium.WaitForPageToLoad("30000");
        }
    }
}
