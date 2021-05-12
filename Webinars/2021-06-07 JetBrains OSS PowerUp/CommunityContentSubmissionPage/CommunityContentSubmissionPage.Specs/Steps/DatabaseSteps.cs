using CommunityContentSubmissionPage.Specs.Drivers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CommunityContentSubmissionPage.Specs.Steps
{
    [Binding]
    public class DatabaseSteps
    {
        private readonly SubmissionDriver _submissionDriver;

        public DatabaseSteps(SubmissionDriver submissionDriver)
        {
            _submissionDriver = submissionDriver;
        }

        [Given(@"the following content suggestions exist")]
        public void GivenTheFollowingContentSuggestionsExist(Table table)
        {
        }

        [Then(@"there is a submission entry stored with the following data:")]
        [Then(@"the following content suggestions exist")]
        public void ThenThereIsASubmissionEntryStoredWithTheFollowingData(Table table)
        {
            var expectedSubmissionContentEntry = table.CreateInstance<ExpectedSubmissionContentEntry>();

            _submissionDriver.AssertSubmissionEntryData(expectedSubmissionContentEntry);
        }
    }
}