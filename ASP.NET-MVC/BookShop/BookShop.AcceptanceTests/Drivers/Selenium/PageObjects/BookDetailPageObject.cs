using OpenQA.Selenium;

namespace BookShop.AcceptanceTests.Drivers.Selenium.PageObjects
{
    class BookDetailPageObject
    {
        private readonly IWebDriver _webDriver;

        public BookDetailPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string Title => _webDriver.FindElement(By.Id("title")).Text;
        public string Author => _webDriver.FindElement(By.Id("author")).Text;

        public string Price => _webDriver.FindElement(By.Id("price")).Text;
    }
}
