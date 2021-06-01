﻿using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using CommunityContentSubmissionPage.Test.Common;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace CommunityContentSubmissionPage.Specs.Steps
{
    [Binding]
    public class WebPageSteps
    {
        private readonly Actor _actor;

        public WebPageSteps(Actor actor)
        {
            _actor = actor;
        }

        [Given(@"the submission page is opened")]
        [When(@"the submission page is opened")]
        public void WhenTheSubmissionPageIsOpen()
        {
            _actor.AttemptsTo(Navigate.ToUrl(ConfigurationProvider.BaseAddress));
        }

        [Then(@"the title of the page is '(.*)'")]
        public void ThenTheTitleOfThePageIs(string expectedPageTitle)
        {
            _actor.AskingFor(Title.OfPage()).Should().Be(expectedPageTitle);
        }
    }
}