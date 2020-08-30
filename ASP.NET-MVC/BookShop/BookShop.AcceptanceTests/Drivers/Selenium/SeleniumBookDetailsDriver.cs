using System;
using System.Globalization;
using BookShop.AcceptanceTests.Drivers.RowObjects;
using BookShop.AcceptanceTests.Drivers.Selenium.PageObjects;
using BookShop.AcceptanceTests.Support.Database;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BookShop.AcceptanceTests.Drivers.Selenium
{
    class SeleniumBookDetailsDriver : IBookDetailsDriver
    {
        private readonly BrowserDriver _browserDriver;
        private readonly WebServerDriver _webServerDriver;
        private readonly CatalogContext _catalogContext;

        public SeleniumBookDetailsDriver(BrowserDriver browserDriver, WebServerDriver webServerDriver, CatalogContext catalogContext)
        {
            _browserDriver = browserDriver;
            _webServerDriver = webServerDriver;
            _catalogContext = catalogContext;
        }

        public void OpenBookDetails(string bookTitle)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookTitle);

            var bookIdUrl = $"{_webServerDriver.Hostname}/Catalog/Details/{book.Id}";
            _browserDriver.Current.Navigate().GoToUrl(bookIdUrl);

            RetryHelper.WaitFor(() => _browserDriver.Current.Url == bookIdUrl);
        }

        public void ShowsBookDetails(Table expectedBookDetails)
        {
            var expectedBook = expectedBookDetails.CreateInstance<BookRow>();

            var bookDetailPageObject = new BookDetailPageObject(_browserDriver.Current);

            if (expectedBook.Title != null)
            {
                bookDetailPageObject.Title.Should().Be(expectedBook.Title);
            }

            if (expectedBook.Author != null)
            {
                bookDetailPageObject.Author.Should().Be(expectedBook.Author);
            }

            if (expectedBook.Price != null)
            {
                var actualPrice = decimal.Parse(bookDetailPageObject.Price[2..], CultureInfo.CurrentUICulture);
                var expectedPrice = Convert.ToDecimal(expectedBook.Price);
                actualPrice.Should().Be(expectedPrice);
            }

        }
    }
}