using FluentAssertions;
using SpecFlow.Actions.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlow.Actions.Docker.IntegrationTests
{
    [Binding]
    public class Steps
    {
        private readonly IBrowserInteractions _browserInteractions;
        private readonly BrowserDriver _browserDriver;

        public Steps(IBrowserInteractions browserInteractions, BrowserDriver browserDriver)
        {
            _browserInteractions = browserInteractions;
            _browserDriver = browserDriver;
        }

        [Given("a new installation of WordPress")]
        public void ANewInstallationOfWordPress()
        {

        }

        [When("the user first visits")]
        public void TheUserFirstVisits()
        {
            _browserInteractions.GoToUrl("http://localhost:8000");
        }

        [Then("the user is presented the installation start page")]
        public void TheUserIsPresentedTheInstallationStartPage()
        {
            for (var i = 0; i < 5; i++)
            {
                var currentTitle = _browserDriver.Current.Title;

                if (currentTitle != "WordPress › Installation")
                {
                    _browserDriver.Current.Navigate().Refresh();
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                }
            }

            _browserDriver.Current.Title.Should().Be("WordPress › Installation");
        }
    }
}