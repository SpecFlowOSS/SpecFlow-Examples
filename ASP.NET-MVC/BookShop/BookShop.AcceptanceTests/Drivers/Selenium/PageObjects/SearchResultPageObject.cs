using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace BookShop.AcceptanceTests.Drivers.Selenium.PageObjects
{
    class SearchResultPageObject
    {
        private readonly IWebDriver _webDriver;

        public SearchResultPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public IWebElement ResultTable => _webDriver.FindElement(By.Id("searchResultTable"));

        public IEnumerable<IWebElement> TableLines => ResultTable.FindElements(By.TagName("tr"));

        public IEnumerable<BookListEntry> SearchResults => TableLines.Skip(1).Select(r => new BookListEntry(r));
    }
}
