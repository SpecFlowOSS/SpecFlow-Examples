using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlow.BrowserStack
{
	[Binding]
	public class GoogleSteps
	{
		readonly IWebDriver _driver;

		public GoogleSteps()
		{
			_driver = (IWebDriver)ScenarioContext.Current["driver"];
		}

		[Given(@"I am on the google page")]
		public void GivenIAmOnTheGooglePage()
		{
			_driver.Navigate().GoToUrl("http://www.google.com");
		}

		[When(@"I search the web")]
		public void WhenISearchTheWeb()
		{
			var q = _driver.FindElement(By.Name("q"));
			q.SendKeys("Kenneth Truyers");
			q.Submit();
		}

		[Then(@"I get search results")]
		public void ThenIGetSearchResults()
		{
			Thread.Sleep(15000);
			Assert.That(_driver.FindElement(By.Id("resultStats")).Text, Is.Not.Empty);
		}
	}
}
