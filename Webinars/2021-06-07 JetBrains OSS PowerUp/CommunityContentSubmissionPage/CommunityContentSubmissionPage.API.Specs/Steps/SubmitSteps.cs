using System;
using System.Collections.Generic;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;

namespace CommunityContentSubmissionPage.API.Specs.Steps
{
    [Binding]
    public class SubmitSteps
    {
        private readonly RestClient _restClient;
        private readonly Submission _submission = new();
        private IRestResponse _submitFormResponse;

        public SubmitSteps(RestClient restClient)
        {
            _restClient = restClient;
        }

        [Given(@"the following submission entry")]
        [Given(@"the content suggestion page is opened and filled with")]
        public void GivenTheFollowingSubmissionEntry(Table table)
        {
            var submissionEntryFormRowObjects = table.CreateSet<SubmissionEntryFormRowObject>();

            foreach (var rowObject in submissionEntryFormRowObjects)
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
                    case "PRIVACY POLICY":
                        _submission.AcceptPrivacyPolicy = rowObject.Value == "Accepted";
                        break;
                    default:
                        throw new NotImplementedException($"{rowObject.Label} is not implemented");
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
        [Given(@"a filled content suggestion page will be submitted")]
        public void GivenTheSubmissionEntryIsComplete()
        {
            _submission.Url = "https://www.example.org";
            _submission.Type = "Blog Posts";
            _submission.Email = "someone@example.org";
            _submission.Description = "a description";
            _submission.Name = "Jane Doe";
            _submission.AcceptPrivacyPolicy = true;
        }

        [When(@"the submission entry is submitted")]
        [When(@"the form is submitted")]
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
            _submission.Name = string.Empty;
        }

        [Given(@"'(.*)' is left out")]
        public void GivenIsLeftOut(string name)
        {
            switch (name.ToUpper())
            {
                case "URL":
                    _submission.Url = string.Empty;
                    break;
                case "TYPE":
                    _submission.Type = string.Empty;
                    break;
                case "EMAIL":
                    _submission.Email = string.Empty;
                    break;
                case "DESCRIPTION":
                    _submission.Description = string.Empty;
                    break;
                case "NAME":
                    _submission.Name = string.Empty;
                    break;
                case "PRIVACY POLICY":
                    _submission.AcceptPrivacyPolicy = false;
                    break;
                default:
                    throw new NotImplementedException($"{name} is not implemented");
            }
        }

        [Then(@"the following error '(.*)' is shown for field '(.*)'")]
        public void ThenTheFollowingErrorIsShownForField(string errorMessage, string fieldName)
        {
            _submitFormResponse.IsSuccessful.Should().BeFalse();

            var jObject = JObject.Parse(_submitFormResponse.Content);
            List<string> errorsFromField;

            try
            {
                var errors = jObject["errors"] as JObject;
                
                errorsFromField = (errors[GetRealFieldName(fieldName)] as JArray).Select(e => e.Value<string>()).ToList();
            }
            catch (Exception)
            {
                throw new Exception("Wrong JSON response");
            }

            errorsFromField.Should().Contain(errorMessage);
        }

        private string GetRealFieldName(string fieldName)
        {
            if (fieldName == "Privacy Policy")
            {
                return "AcceptPrivacyPolicy";
            }

            return fieldName;
        }
    }
    
    public class Errors
    {
        [JsonProperty("Name")]
        public List<string> Name { get; set; }
    }

    public class Root
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("traceId")]
        public string TraceId { get; set; }

        [JsonProperty("errors")]
        public Errors Errors { get; set; }
    }
    
}