using System;
using System.Collections.Generic;
using System.Text;
using CommunityContentSubmissionPage.API.Specs.Drivers;
using CommunityContentSubmissionPage.API.Specs.Support;
using FluentAssertions;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CommunityContentSubmissionPage.API.Specs.Steps
{
    [Binding]
    public class SubmitSteps
    {
        private readonly RestClient _restClient;
        private readonly Submission _submission = new Submission();
        private IRestResponse _submitFormResponse;

        public SubmitSteps(RestClient restClient)
        {
            _restClient = restClient;
        }

        [Given(@"the following submission entry")]
        public void GivenTheFollowingSubmissionEntry(Table table)
        {
            var submissionEntryFormRowObjects = table.CreateSet<SubmissionEntryFormRowObject>();

            foreach (var rowObject in submissionEntryFormRowObjects)
            {
                switch (rowObject.Label.ToUpper())
                {
                    case "URL":
                        _submission.Url = rowObject.Value;
                        break;
                    case "TYPE":
                        _submission.Type = rowObject.Value;
                        break;
                    case "EMAIL":
                        _submission.Email = rowObject.Value;
                        break;
                    case "DESCRIPTION":
                        _submission.Description = rowObject.Value;
                        break;
                    case "NAME":
                        _submission.Name = rowObject.Value;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        [Given(@"the privacy policy is accepted")]
        public void GivenThePrivacyPolicyIsAccepted()
        {
            _submission.AcceptPrivacyPolicy = true;
        }

        [Given(@"the privacy policy is not accepted")]
        public void GivenThePrivacyPolicyIsNotAccepted()
        {
            _submission.AcceptPrivacyPolicy = false;
        }


        [Given(@"the submission entry is complete")]
        public void GivenTheSubmissionEntryIsComplete()
        {
            _submission.Url = "https://www.example.org";
            _submission.Type = "Blog Posts";
            _submission.Email = "someone@example.org";
            _submission.Description = "a description";
            _submission.Name = "Jane Doe";
        }

        [When(@"the submission entry is submitted")]
        public void WhenTheSubmissionEntryIsSubmitted()
        {
            
            var restRequest = new JsonRequest<Submission, string>("api/Submit", _submission);

            _submitFormResponse = _restClient.Post(restRequest);
        }

        [Then(@"the submitting of data was possible")]
        public void ThenTheSubmittingOfDataWasPossible()
        {
            _submitFormResponse.IsSuccessful.Should().BeTrue();
        }

        [Then(@"the submitting of data was not possible")]
        public void ThenTheSubmittingOfDataWasNotPossible()
        {
            _submitFormResponse.IsSuccessful.Should().BeFalse();
        }

        [Given(@"all necessary fields except the name are filled out")]
        public void GivenAllNecessaryFieldsExceptTheNameAreFilledOut()
        {
            _submission.Url = "https://www.example.org";
            _submission.Type = "Blog Posts";
            _submission.Email = "someone@example.org";
            _submission.Description = "a description";
            _submission.AcceptPrivacyPolicy = true;
        }

        [When(@"the name '(.*)' is provided")]
        public void WhenTheNameIsProvided(string name)
        {
            _submission.Name = name;
        }

        [When(@"the name stays empty")]
        public void WhenTheNameStaysEmpty()
        {
            _submission.Name = String.Empty;
        }
    }
}
