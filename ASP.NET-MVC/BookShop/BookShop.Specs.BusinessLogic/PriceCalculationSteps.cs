using BookShop.Models;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BookShop.Specs.BusinessLogic
{
    [Binding]
    public class PriceCalculationSteps
    {
        private readonly ShoppingCart _shoppingCart;

        public PriceCalculationSteps(ShoppingCartContext shoppingCartContext)
        {
            _shoppingCart = shoppingCartContext.ShoppingCart;
        }

        [Given(@"I have a book with price '(.*)' and quantity '(\d*)' in my shopping cart")]
        public void GivenIHaveABookWithPrice10_05AndQuantity1InMyShoppingCart(decimal price, int quantity)
        {
            Book book = new Book {Price = price};
            _shoppingCart.AddLineItem(new LineItem {Book = book, Quantity = quantity});
        }

        [Then(@"the total price should be '(.*)'")]
        public void ThenTheTotalPriceShouldBe10_05(decimal price)
        {
            Assert.AreEqual(price, _shoppingCart.Price);
        }
    }
}
