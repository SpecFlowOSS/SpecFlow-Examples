using BookShop.AcceptanceTests.Drivers;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class ShoppingCartSteps
    {
        private readonly IShoppingCartDriver _driver;

        public ShoppingCartSteps(IShoppingCartDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I have a shopping cart with: '(.*)'")]
        public void GivenIHaveAShoppingCartWith(string bookTitles)
        {
            _driver.SetShoppingCart(bookTitles);
        }

        [Given(@"the shop is closed")]
        public void GivenTheShopIsClosed()
        {
            //not used
        }

        [When(@"I place '(.*)' into the shopping cart")]
        public void WhenIPlaceIntoTheShoppingCart(string bookTitle)
        {
            _driver.Place(bookTitle);
        }

        [When(@"I delete '(.*)' from the shopping cart")]
        [When(@"I remove the book '(.*)' from the shopping cart")] //not used regex
        public void WhenIDeleteFromTheShoppingCart(string bookTitle)
        {
            _driver.Delete(bookTitle);
        }

        [When(@"I change the quantity of '(.*)' to (\d+)")]
        public void WhenIChangeTheQuantityOfTo(string bookTitle, int quantity)
        {
            _driver.SetQuantity(bookTitle, quantity);
        }

        [Then(@"my shopping cart should be empty")]
        public void ThenMyShoppingCartShouldBeEmpty()
        {
            _driver.ContainsTypesOfItems(0);
        }

        [Then(@"my shopping cart should contain (\d+) types? of items?")]
        public void ThenMyShoppingCartShouldContainTypesOfItems(int expectedItemTypeCount)
        {
            _driver.ContainsTypesOfItems(expectedItemTypeCount);
        }

        [Then(@"my shopping cart should contain (\d+) cop(?:y|ies) of '(.*)'")]
        public void ThenMyShoppingCartShouldContainCopiesOf(int expectedQuantity, string expectedBookTitle)
        {
            _driver.ContainsCopiesOf(expectedBookTitle, expectedQuantity);
        }

        [Then(@"my shopping cart should contain (\d+) items in total")]
        public void ThenMyShoppingCartShouldContainItemsInTotal(int expectedQuantity)
        {
            _driver.ContainsTotalItems(expectedQuantity);
        }

        [Then(@"my shopping cart should show a total price of (.*)")]
        public void ThenMyShoppingCartShouldShowATotalPriceOf(decimal expectedTotalPrice)
        {
            _driver.ShowsTotalPriceOf(expectedTotalPrice);       
        }

        [StepDefinition(@"I proceed to checkout")]
        public void StepDefinitionIProceedToCheckout()
        {
            //not used step
        }

    }
}
