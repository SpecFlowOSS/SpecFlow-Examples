using System.Collections.Generic;
using System.Linq;
using BookShop.AcceptanceTests.Drivers.RowObjects;
using BookShop.AcceptanceTests.Drivers.Selenium.PageObjects;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BookShop.AcceptanceTests.Drivers.Selenium
{
    class SeleniumHomeDriver : IHomeDriver
    {
        private readonly BrowserDriver _browserDriver;
        private readonly WebServerDriver _webServerDriver;

        public SeleniumHomeDriver(BrowserDriver browserDriver, WebServerDriver webServerDriver)
        {
            _browserDriver = browserDriver;
            _webServerDriver = webServerDriver;
        }
        public void Navigate()
        {
            _browserDriver.Current.Navigate().GoToUrl(_webServerDriver.Hostname);
        }

        public void ShowsBook(string expectedTitle)
        {
            var homePageObject = new HomePageObject(_browserDriver.Current);

            homePageObject.CheapestThreeBooks.Should().Contain(i => i.Title == expectedTitle);
        }

        public void ShowsBooks(string expectedTitlesString)
        {
            var expectedTitles = from t in expectedTitlesString.Split(',')
                select t.Trim().Trim('\'');

            var homePageObject = new HomePageObject(_browserDriver.Current);

            var actualTitles = homePageObject.CheapestThreeBooks.Select(i => i.Title);

            actualTitles.Should().BeEquivalentTo(expectedTitles);
        }

        public void ShowsBooks(Table expectedBooks)
        {
            ShowsBooks(expectedBooks.CreateSet<BookRow>().Select(i => i.Title));
        }

        private void ShowsBooks(IEnumerable<string> expectedTitles)
        {
            var homePageObject = new HomePageObject(_browserDriver.Current);

            var actualTitles = homePageObject.CheapestThreeBooks.Select(i => i.Title);

            actualTitles.Should().BeEquivalentTo(expectedTitles);
        }
    }
}