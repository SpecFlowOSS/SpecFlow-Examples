using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using OpenQA.Selenium;

namespace BookShop.AcceptanceTests.Drivers.Selenium.PageObjects
{
    class ShoppingCartPageObject
    {
        private readonly IWebDriver _webDriver;

        public ShoppingCartPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public int ShoppingCartCount => int.Parse(_webDriver.FindElement(By.ClassName("shoppingcart_count")).Text);

        public IWebElement Table => _webDriver.FindElement(By.ClassName("table"));

        public IEnumerable<BookListEntry> Books =>
            Table.FindElements(By.TagName("tr")).Skip(1).SkipLast(1).Select(i => new BookListEntry(i));

        public decimal TotalPrice =>
            decimal.Parse(_webDriver.FindElement(By.ClassName("shoppingcart_total_amount")).Text[2..], CultureInfo.CurrentUICulture);
    }
}
