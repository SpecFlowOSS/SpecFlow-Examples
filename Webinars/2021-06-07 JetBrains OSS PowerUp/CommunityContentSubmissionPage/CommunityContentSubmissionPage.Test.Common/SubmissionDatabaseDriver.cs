using CommunityContentSubmissionPage.Database;
using System.Linq;
using CommunityContentSubmissionPage.Database.Model;
using FluentAssertions;

namespace CommunityContentSubmissionPage.Test.Common
{
    public class SubmissionDatabaseDriver
    {
        private readonly IDatabaseContext _databaseContext;

        public SubmissionDatabaseDriver(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
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

        public void CreateSubmissionEntry(ExpectedSubmissionContentEntry expectedSubmissionContentEntry)
        {
            var submissionEntry = new SubmissionEntry
            {
                Description = expectedSubmissionContentEntry.Description,
                Email = expectedSubmissionContentEntry.Email,
                Name = expectedSubmissionContentEntry.Name,
                Type = expectedSubmissionContentEntry.Type,
                Url = expectedSubmissionContentEntry.Url
            };

            _databaseContext.SubmissionEntries.Add(submissionEntry);
            _databaseContext.SaveChangesAsync();
        }

        public void AssertDatabaseIsEmpty()
        {
            _databaseContext.SubmissionEntries.Should().BeEmpty();
        }
    }
}