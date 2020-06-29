using System.Linq;
using BookShop.AcceptanceTests.Drivers.Selenium.PageObjects;
using FluentAssertions;

namespace BookShop.AcceptanceTests.Drivers.Selenium
{
    class SeleniumShoppingCartDriver : IShoppingCartDriver
    {
        private readonly BrowserDriver _browserDriver;
        private readonly SeleniumHomeDriver _seleniumHomeDriver;

        public SeleniumShoppingCartDriver(BrowserDriver browserDriver, SeleniumHomeDriver seleniumHomeDriver)
        {
            _browserDriver = browserDriver;
            _seleniumHomeDriver = seleniumHomeDriver;
        }

        public void Navigate()
        {
            _browserDriver.Navigate("ShoppingCart");
        }

        public void SetShoppingCart(string bookTitles)
        {
            foreach (string bookId in from i in bookTitles.Split(',')
                select i.Trim().Trim('\''))
            {
                Place(bookId);
            }
        }

        public void Place(string bookTitle)
        {
            _seleniumHomeDriver.Navigate();

            var homePageObject = new HomePageObject(_browserDriver.Current);
            homePageObject.Search(bookTitle);

            var searchResultPageObject = new SearchResultPageObject(_browserDriver.Current);

            var bookListEntries = searchResultPageObject.SearchResults.ToList();
            var entry = bookListEntries.Single(i => i.Title == bookTitle);
            entry.AddToCart();

            RetryHelper.WaitFor(() => _browserDriver.Current.Url.EndsWith("ShoppingCart"));
        }

        public void Delete(string bookTitle)
        {
            var shoppingCartPageObject = new ShoppingCartPageObject(_browserDriver.Current);

            var book = shoppingCartPageObject.Books.Single(i => i.Title == bookTitle);

            book.RemoveFromCart();
        }

        public void SetQuantity(string bookTitle, int quantity)
        {
            var shoppingCartPageObject = new ShoppingCartPageObject(_browserDriver.Current);

            var book = shoppingCartPageObject.Books.Single(i => i.Title == bookTitle);

            book.Quantity = quantity;
        }

        public void ContainsTypesOfItems(int expectedAmount)
        {
            Navigate();

            var shoppingCartPageObject = new ShoppingCartPageObject(_browserDriver.Current);
            shoppingCartPageObject.Books.Count().Should().Be(expectedAmount);
        }

        public void ContainsTotalItems(int expectedQuantity)
        {
            Navigate();

            var shoppingCartPageObject = new ShoppingCartPageObject(_browserDriver.Current);
            shoppingCartPageObject.ShoppingCartCount.Should().Be(expectedQuantity);
        }

        public void ShowsTotalPriceOf(decimal expectedTotalPrice)
        {
            Navigate();

            var shoppingCartPageObject = new ShoppingCartPageObject(_browserDriver.Current);
            shoppingCartPageObject.TotalPrice.Should().Be(expectedTotalPrice);
        }

        public void ContainsCopiesOf(string bookTitle, int expectedQuantity)
        {
            var shoppingCartPageObject = new ShoppingCartPageObject(_browserDriver.Current);

            var book = shoppingCartPageObject.Books.Single(i => i.Title == bookTitle);

            book.Quantity.Should().Be(expectedQuantity);
        }
    }
}