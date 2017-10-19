using BookShop.AcceptanceTests.Drivers.Search;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class SearchSteps
    {
        private readonly SearchDriver _searchDriver;
        private readonly SearchResultDriver _searchResultDriver;

        public SearchSteps(SearchDriver searchDriver, SearchResultDriver searchResultDriver)
        {
            this._searchDriver = searchDriver;
            this._searchResultDriver = searchResultDriver;
        }

        [When(@"I search for books by the phrase '(.*)'")]
        public void WhenISearchForBooksByThePhrase(string searchTerm)
        {
            this._searchDriver.Search(searchTerm);
        }

        [Then(@"the list of found books should contain only: (.*)")]
        public void ThenTheListOfFoundBooksShouldContainOnly(string expectedTitleList)
        {
            this._searchResultDriver.ShowsBooks(expectedTitleList);    
        }

        [Then(@"the list of found books should be:")]
        public void ThenTheListOfFoundBooksShouldBe(Table expectedBooks)
        {
            this._searchResultDriver.ShowsBooks(expectedBooks);
        }

    }
}
