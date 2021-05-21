using CommunityContentSubmissionPage.API.Specs.Drivers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CommunityContentSubmissionPage.API.Specs.Steps
{
    [Binding]
    public class SubmissionSteps
    {
        private readonly SubmissionDriver _submissionDriver;
        
        public SubmissionSteps(SubmissionDriver submissionDriver)
        {
            _submissionDriver = submissionDriver;
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

        
        [Then(@"there is a submission entry stored with the following data:")]
        public void ThenThereIsASubmissionEntryStoredWithTheFollowingData(Table table)
        {
            var expectedSubmissionContentEntry = table.CreateInstance<ExpectedSubmissionContentEntry>();

            _submissionDriver.AssertSubmissionEntryData(expectedSubmissionContentEntry);
        }

    }
}