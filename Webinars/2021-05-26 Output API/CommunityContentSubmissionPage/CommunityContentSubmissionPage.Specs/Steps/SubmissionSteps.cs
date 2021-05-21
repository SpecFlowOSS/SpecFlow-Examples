using System;
using System.Collections.Generic;
using System.Linq;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using CommunityContentSubmissionPage.Specs.Drivers;
using CommunityContentSubmissionPage.Specs.Interactions;
using CommunityContentSubmissionPage.Specs.Pages;
using CommunityContentSubmissionPage.Specs.Support;
using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CommunityContentSubmissionPage.Specs.Steps
{
    [Binding]
    public class SubmissionSteps
    {
        private readonly Actor _actor;
        private readonly SubmissionDriver _submissionDriver;
        
        public SubmissionSteps(SubmissionDriver submissionDriver, Actor actor)
        {
            _submissionDriver = submissionDriver;
            _actor = actor;
        }

        [Then(@"it is possible to enter a '(.*)' with label '(.*)'")]
        public void ThenItIsPossibleToEnterAWithLabel(string inputType, string expectedLabel)
        {
            IWebLocator inputFieldLocator;
            IWebLocator labelLocator;

            switch (inputType.ToUpper())
            {
                case "URL":
                    inputFieldLocator = SubmissionPage.UrlInputField;
                    labelLocator = SubmissionPage.UrlLabel;
                    break;
                case "TYPE":
                    inputFieldLocator = SubmissionPage.TypeSelect;
                    labelLocator = SubmissionPage.TypeLabel;
                    break;
                case "EMAIL":
                    inputFieldLocator = SubmissionPage.EmailInputField;
                    labelLocator = SubmissionPage.EmailLabel;
                    break;
                case "DESCRIPTION":
                    inputFieldLocator = SubmissionPage.DescriptionInputField;
                    labelLocator = SubmissionPage.DescriptionLabel;
                    break;
                default: 
                    throw new NotImplementedException();
            }

            _actor.AttemptsTo(Wait.Until(Appearance.Of(inputFieldLocator), IsEqualTo.True()));
            _actor.AskingFor(Text.Of(labelLocator)).Should().Be(expectedLabel);
        }

        [Given(@"the filled out submission entry form")]
        public void GivenTheFilledOutSubmissionEntryForm(Table table)
        {
            var rows = table.CreateSet<SubmissionEntryFormRowObject>();
            
            _actor.AttemptsTo(FillOutSubmissionForm.With(rows));
        }

        [When(@"the submission entry form is submitted")]
        public void WhenTheSubmissionEntryFormIsSubmitted()
        {
            _actor.AttemptsTo(Click.On(SubmissionPage.SubmitButton));
        }

        [Then(@"there is one submission entry stored")]
        public void ThenThereIsOneSubmissionEntryStored()
        {
            _submissionDriver.AssertOneSubmissionEntryExists();
        }

        [Then(@"there is '(.*)' submission entry stored")]
        public void ThenThereIsSubmissionEntryStored(int expectedCountOfStoredEntries)
        {
            _submissionDriver.AssertNumberOfEntriesStored(expectedCountOfStoredEntries);
        }

        [Then(@"the submitting of data was possible")]
        public void ThenTheSubmittingOfDataWasPossible()
        {
            
            _actor.AsksFor(CurrentUrl.FromBrowser()).Should().EndWith("Success", "because the success page should be displayed");
        }

        [Then(@"the submitting of data was not possible")]
        public void ThenTheSubmittingOfDataWasNotPossible()
        {
            _actor.AsksFor(CurrentUrl.FromBrowser()).Should().NotEndWith("Success", "the input form page should be displayed again");
        }


        [Then(@"there is a submission entry stored with the following data:")]
        public void ThenThereIsASubmissionEntryStoredWithTheFollowingData(Table table)
        {
            var expectedSubmissionContentEntry = table.CreateInstance<ExpectedSubmissionContentEntry>();

            _submissionDriver.AssertSubmissionEntryData(expectedSubmissionContentEntry);
        }

        [Then(@"you can choose from the following Types:")]
        public void ThenYouCanChooseFromTheFollowingTypes(Table table)
        {
            var expectedTypenameEntries = table.CreateSet<TypenameEntry>();
            var actualTypes = _actor.AsksFor(SelectOptionsAvailable.For(SubmissionPage.TypeSelect)).Select(i => new TypenameEntry(i));

            actualTypes.Should().BeEquivalentTo(expectedTypenameEntries);

        }

        [Given(@"the submission entry form is filled")]
        public void GivenTheSubmissionEntryFormIsFilled()
        {
            var submissionEntryFormRowObjects = new List<SubmissionEntryFormRowObject>
            {
                new SubmissionEntryFormRowObject("Url", "https://example.org"),
                new SubmissionEntryFormRowObject("Type", "Blog Posts"),
                new SubmissionEntryFormRowObject("Email", "someone@example.org"),
                new SubmissionEntryFormRowObject("Description", "something really cool"),
                new SubmissionEntryFormRowObject("Name", "Jane Doe")
            };
            
            _actor.AttemptsTo(FillOutSubmissionForm.With(submissionEntryFormRowObjects));
        }

        [Given(@"the privacy policy is not accepted")]
        public void GivenThePrivacyPolicyIsNotAccepted()
        {
            var privacyPolicyIsChecked = _actor.AskingFor(SelectedState.Of(SubmissionPage.PrivacyPolicy));
            if (privacyPolicyIsChecked)
            {
                _actor.AttemptsTo(Click.On(SubmissionPage.PrivacyPolicy));
            }
        }

        [Given(@"the privacy policy is accepted")]
        public void GivenThePrivacyPolicyIsAccepted()
        {
            _actor.AttemptsTo(Click.On(SubmissionPage.PrivacyPolicy));
        }

        [When(@"the form is reset")]
        public void WhenTheFormIsReset()
        {
            _actor.AttemptsTo(Click.On(SubmissionPage.CancelButton));
        }

        [Then(@"every input is set to its default values")]
        public void ThenEveryInputIsSetToItsDefaultValues()
        {
            _actor.AsksFor(Text.Of(SubmissionPage.UrlInputField)).Should().BeEmpty();
            _actor.AsksFor(SelectedOptionText.Of(SubmissionPage.TypeSelect)).Should().Be("Blog Posts");
            _actor.AsksFor(Text.Of(SubmissionPage.EmailInputField)).Should().BeEmpty();
            _actor.AsksFor(Text.Of(SubmissionPage.DescriptionInputField)).Should().BeEmpty();
            _actor.AsksFor(SelectedState.Of(SubmissionPage.PrivacyPolicy)).Should().BeFalse();
        }

        [Given(@"all necessary fields except the name are filled out")]
        public void GivenAllNecessaryFieldsExceptTheNameAreFilledOut()
        {
            var submissionEntryFormRowObjects = new List<SubmissionEntryFormRowObject>
            {
                new SubmissionEntryFormRowObject("Url", "https://example.org"),
                new SubmissionEntryFormRowObject("Type", "Blog Posts"),
                new SubmissionEntryFormRowObject("Email", "someone@example.org"),
                new SubmissionEntryFormRowObject("Description", "something really cool")
            };
            
            _actor.AttemptsTo(FillOutSubmissionForm.With(submissionEntryFormRowObjects));
            _actor.AttemptsTo(Click.On(SubmissionPage.PrivacyPolicy));
        }

        [When(@"the name '(.*)' is provided")]
        public void WhenTheNameIsProvided(string name)
        {
            _actor.AttemptsTo(SendKeys.To(SubmissionPage.NameField, name));
        }

        [When(@"the name stays empty")]
        public void WhenTheNameStaysEmpty()
        {
            _actor.AttemptsTo(SendKeys.To(SubmissionPage.NameField, string.Empty));
        }
    }
}