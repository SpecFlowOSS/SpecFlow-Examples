using BookShop.AcceptanceTests.Drivers;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class SearchSteps
    {
        private readonly ISearchDriver _searchDriver;
        private readonly ISearchResultDriver _searchResultDriver;

        public SearchSteps(ISearchDriver searchDriver, ISearchResultDriver searchResultDriver)
        {
            _searchDriver = searchDriver;
            _searchResultDriver = searchResultDriver;
        }

        [When(@"I search for books by the phrase '(.*)'")]
        public void WhenISearchForBooksByThePhrase(string searchTerm)
        {
            _searchDriver.Search(searchTerm);
        }

        [When(@"I remove the search criteria")]
        public void WhenIRemoveTheSearchCriteria()
        {
            //not used step
        }

        [Then(@"the list of found books should contain only: (.*)")]
        public void ThenTheListOfFoundBooksShouldContainOnly(string expectedTitleList)
        {
            _searchResultDriver.ShowsBooks(expectedTitleList);    
        }

        [Then(@"the list of found books should be:")]
        public void ThenTheListOfFoundBooksShouldBe(Table expectedBooks)
        {
            _searchResultDriver.AssertBooksInResult(expectedBooks);
        }

    }
}
