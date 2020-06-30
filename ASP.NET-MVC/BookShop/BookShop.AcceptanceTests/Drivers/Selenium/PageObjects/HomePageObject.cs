using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace BookShop.AcceptanceTests.Drivers.Selenium.PageObjects
{
    class HomePageObject
    {
        private readonly IWebDriver _webDriver;

        public HomePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public IWebElement SearchTerm => _webDriver.FindElement(By.Id("searchTerm"));

        public IWebElement SearchButton => _webDriver.FindElement(By.Id("searchForm"));

        public IWebElement BookTable => _webDriver.FindElement(By.ClassName("table"));

        public IEnumerable<IWebElement> TableLines => BookTable.FindElements(By.TagName("tr"));

        public IEnumerable<BookListEntry> CheapestThreeBooks => TableLines.Skip(1).Select(r => new BookListEntry(r));

        public void Search(string term)
        {
            SearchTerm.Clear();
            SearchTerm.SendKeys(term);

            SearchButton.Submit();

            RetryHelper.WaitFor(() => _webDriver.Url.EndsWith("Catalog/Search"));


        }
    }
}
