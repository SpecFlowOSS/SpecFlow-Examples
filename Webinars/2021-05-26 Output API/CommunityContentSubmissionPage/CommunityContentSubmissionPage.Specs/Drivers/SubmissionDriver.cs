using System.Linq;
using CommunityContentSubmissionPage.Business.Infrastructure;
using CommunityContentSubmissionPage.Database;
using CommunityContentSubmissionPage.Specs.Steps;
using FluentAssertions;

namespace CommunityContentSubmissionPage.Specs.Drivers
{
    public class SubmissionDriver
    {
        private readonly IDatabaseContext _databaseContext;

        public SubmissionDriver(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void AssertOneSubmissionEntryExists()
        {
            _databaseContext.SubmissionEntries.Count().Should().BeGreaterThan(0);
        }

        public void AssertNumberOfEntriesStored(int expectedCountOfStoredEntries)
        {
            _databaseContext.SubmissionEntries.Count().Should().Be(expectedCountOfStoredEntries);
        }

        public void AssertSubmissionEntryData(ExpectedSubmissionContentEntry expectedSubmissionContentEntry)
        {
            var actualEntry = _databaseContext.SubmissionEntries.Single();

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