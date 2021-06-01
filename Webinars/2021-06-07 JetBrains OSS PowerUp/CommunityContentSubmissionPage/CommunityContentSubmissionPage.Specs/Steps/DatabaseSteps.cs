using System.Linq;
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
            var expectedSubmissionContentEntries = table.CreateSet<ExpectedSubmissionContentEntry>();

            foreach (var expectedSubmissionContentEntry in expectedSubmissionContentEntries)
            {
                _submissionDriver.CreateSubmissionEntry(expectedSubmissionContentEntry);
            }
        }

        [Then(@"there is a submission entry stored with the following data:")]
        [Then(@"the following content suggestions exist")]
        [Then(@"the following saved content suggestion exist")]
        public void ThenThereIsASubmissionEntryStoredWithTheFollowingData(Table table)
        {
            var expectedSubmissionContentEntries = table.CreateSet<ExpectedSubmissionContentEntry>();

            if (expectedSubmissionContentEntries.Any())
            {
                _submissionDriver.AssertSubmissionEntryData(expectedSubmissionContentEntries.Single());    
            }
            else
            {
                _submissionDriver.AssertDatabaseIsEmpty();
            }
            
            
        }


    }
}