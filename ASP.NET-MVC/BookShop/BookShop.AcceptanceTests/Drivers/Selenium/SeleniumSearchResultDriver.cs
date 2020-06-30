using System.Linq;
using BookShop.AcceptanceTests.Drivers.RowObjects;
using BookShop.AcceptanceTests.Drivers.Selenium.PageObjects;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BookShop.AcceptanceTests.Drivers.Selenium
{
    class SeleniumSearchResultDriver : ISearchResultDriver
    {
        private readonly BrowserDriver _browserDriver;

        public SeleniumSearchResultDriver(BrowserDriver browserDriver)
        {
            _browserDriver = browserDriver;
        }
        public void ShowsBooks(string expectedTitlesString)
        {
            var expectedTitles = from t in expectedTitlesString.Split(',')
                select t.Trim().Trim('\'');

            var searchResultPageObject = new SearchResultPageObject(_browserDriver.Current);

            var actualTitles = searchResultPageObject.SearchResults.Select(i => i.Title);

            actualTitles.Should().BeEquivalentTo(expectedTitles);
        }

        public void AssertBooksInResult(Table expectedBooksTable)
        {
            var searchResultPageObject = new SearchResultPageObject(_browserDriver.Current);

            var expectedBooks = expectedBooksTable.CreateSet<BookRow>();

            var expectedBookTitles = expectedBooks.Select(i => i.Title).ToList();
            var actualBookTitles = searchResultPageObject.SearchResults.Select(i => i.Title).ToList();

            actualBookTitles.Should().BeEquivalentTo(actualBookTitles);
        }
    }
}