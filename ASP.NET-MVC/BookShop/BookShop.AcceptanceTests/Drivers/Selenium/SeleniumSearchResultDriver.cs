using System;
using System.Linq;
using BookShop.AcceptanceTests.Drivers.Selenium.PageObjects;
using FluentAssertions;
using TechTalk.SpecFlow;

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
            var searchResultPageObject = new SearchResultPageObject(_browserDriver.Current);

            bool found = false;


            foreach (var searchResultEntry in searchResultPageObject.SearchResults)
            {
                var title = searchResultEntry.Title;
                if (title == expectedTitlesString)
                {
                    found = true;
                }
            }

            found.Should().Be(true, $"{expectedTitlesString} is not found in the list {String.Join(";", searchResultPageObject.SearchResults.Select(i => i.Title))}"  );
        }

        public void ShowsBooks(Table expectedBooks)
        {
            throw new System.NotImplementedException();
        }
    }
}