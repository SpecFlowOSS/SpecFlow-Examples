using BookShop.AcceptanceTests.Drivers.ShoppingCart;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class ShoppingCartSteps
    {
        private readonly ShoppingCartDriver _driver;

        public ShoppingCartSteps(ShoppingCartDriver driver)
        {
            this._driver = driver;
        }

        [Given(@"I have a shopping cart with: '(.*)'")]
        public void GivenIHaveAShoppingCartWith(string bookIds)
        {
            this._driver.SetShoppingCart(bookIds);
        }

        [When(@"I place '(.*)' into the shopping cart")]
        public void WhenIPlaceIntoTheShoppingCart(string bookId)
        {
            this._driver.Place(bookId);
        }

        [When(@"I delete '(.*)' from the shopping cart")]
        public void WhenIDeleteFromTheShoppingCart(string bookId)
        {
            this._driver.Delete(bookId);
        }

        [When(@"I change the quantity of '(.*)' to (\d+)")]
        public void WhenIChangeTheQuantityOfTo(string bookId, int quantity)
        {
            this._driver.SetQuantity(bookId, quantity);
        }

        [Then(@"my shopping cart should be empty")]
        public void ThenMyShoppingCartShouldBeEmpty()
        {
            this._driver.ContainsTypesOfItems(0);
        }

        [Then(@"my shopping cart should contain (\d+) types? of items?")]
        public void ThenMyShoppingCartShouldContainTypesOfItems(int expectedItemTypeCount)
        {
            this._driver.ContainsTypesOfItems(expectedItemTypeCount);
        }

        [Then(@"my shopping cart should contain (\d+) cop(?:y|ies) of '(.*)'")]
        public void ThenMyShoppingCartShouldContainCopiesOf(int expectedQuantity, string expectedBookId)
        {
            this._driver.ContainsCopiesOf(expectedBookId, expectedQuantity);
        }

        [Then(@"my shopping cart should contain (\d+) items in total")]
        public void ThenMyShoppingCartShouldContainItemsInTotal(int expectedQuantity)
        {
            this._driver.ContainsTotalItems(expectedQuantity);
        }


        [Then(@"my shopping cart should show a total price of (.*)")]
        public void ThenMyShoppingCartShouldShowATotalPriceOf(decimal expectedTotalPrice)
        {
            this._driver.ShowsTotalPriceOf(expectedTotalPrice);       
        }
    }
}
