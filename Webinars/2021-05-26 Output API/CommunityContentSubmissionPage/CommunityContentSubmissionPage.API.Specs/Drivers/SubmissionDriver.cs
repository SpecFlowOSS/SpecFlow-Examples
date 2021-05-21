using System;
using System.Collections.Generic;
using System.Linq;
using CommunityContentSubmissionPage.API.Specs.Steps;
using FluentAssertions;
using RestSharp;

namespace CommunityContentSubmissionPage.API.Specs.Drivers
{
    public class SubmissionDriver
    {
        private readonly RestClient _restClient;

        public SubmissionDriver(RestClient restClient)
        {
            _restClient = restClient;
        }

        private List<Submission> GetAllSubmissionEntries()
        {
            var restRequest = new RestRequest("/api/submit", DataFormat.Json);
            var response = _restClient.Get<List<Submission>>(restRequest);

            response.IsSuccessful.Should().BeTrue();

            return response.Data;
        }

        public void AssertOneSubmissionEntryExists()
        {
            GetAllSubmissionEntries().Count().Should().BeGreaterThan(0);
        }

        public void AssertNumberOfEntriesStored(int expectedCountOfStoredEntries)
        {
            GetAllSubmissionEntries().Count().Should().Be(expectedCountOfStoredEntries);
        }

        public void AssertSubmissionEntryData(ExpectedSubmissionContentEntry expectedSubmissionContentEntry)
        {
            var actualEntry = GetAllSubmissionEntries().Single();

            if (expectedSubmissionContentEntry.Url is not null)
                actualEntry.Url.Should().Be(expectedSubmissionContentEntry.Url);

            if (expectedSubmissionContentEntry.Type is not null)
                actualEntry.Type.Should().Be(expectedSubmissionContentEntry.Type);

            if (expectedSubmissionContentEntry.Email is not null)
                actualEntry.Email.Should().Be(expectedSubmissionContentEntry.Email);

            if (expectedSubmissionContentEntry.Description is not null)
                actualEntry.Description.Should().Be(expectedSubmissionContentEntry.Description);
        }
    }
}