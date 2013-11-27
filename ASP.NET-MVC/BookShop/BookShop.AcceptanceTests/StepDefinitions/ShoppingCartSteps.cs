using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using BookShop.AcceptanceTests.Support;
using BookShop.Controllers;
using BookShop.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class ShoppingCartSteps
    {
        private readonly CatalogContext _catalogContext;

        public ShoppingCartSteps(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        private ShoppingCartController GetShoppingCartController()
        {
            var controller = new ShoppingCartController();
            HttpContextStub.SetupController(controller);
            return controller;
        }

        [Given(@"I have a shopping cart with: '(.*)'")]
        public void GivenIHaveAShoppingCartWith(string bookIdList)
        {
            var bookIds = bookIdList.Split(',').Select(t => t.Trim().Trim('\''));

            foreach (string bookId in bookIds)
            {
                WhenIPlaceIntoTheShoppingCart(bookId);
            }
        }

        [When(@"I place '(.*)' into the shopping cart")]
        public void WhenIPlaceIntoTheShoppingCart(string bookId)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookId);

            var controller = GetShoppingCartController();
            controller.Add(book.Id);
        }

        [When(@"I delete '(.*)' from the shopping cart")]
        public void WhenIDeleteFromTheShoppingCart(string bookId)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookId);

            var controller = GetShoppingCartController();
            controller.DeleteItem(book.Id);
        }

        [When(@"I change the quantity of '(.*)' to (\d+)")]
        public void WhenIChangeTheQuantityOfTo(string bookId, int quantity)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookId);

            var controller = GetShoppingCartController();
            controller.Edit(new ShoppingCartController.EditArguments{BookId = book.Id, Quantity = quantity});
        }

        [Then(@"my shopping cart should be empty")]
        public void ThenMyShoppingCartShouldBeEmpty()
        {
            ThenMyShoppingCartShouldContainTypesOfItems(0);
        }

        [Then(@"my shopping cart should contain (\d+) types? of items?")]
        public void ThenMyShoppingCartShouldContainTypesOfItems(int expectedItemTypeCount)
        {
            var controller = GetShoppingCartController();
            var actionResult = controller.Index();
            var foundItemTypeCount = actionResult.Model<ShoppingCart>().Lines.Count();

            Assert.AreEqual(expectedItemTypeCount, foundItemTypeCount, 
                "The shopping cart does not contain the expected number of item types.");
        }

        [Then(@"my shopping cart should contain (\d+) cop(?:y|ies) of '(.*)'")]
        public void ThenMyShoppingCartShouldContainCopiesOf(int expectedQuantity, string expectedBookId)
        {
            var expectedBook = _catalogContext.ReferenceBooks.GetById(expectedBookId);

            var controller = GetShoppingCartController();
            var actionResult = controller.Index();

            var line = actionResult.Model<ShoppingCart>().Lines.FirstOrDefault(l => l.Book.Id == expectedBook.Id);
            Assert.IsNotNull(line, "The shopping cart does not contain the expected book.");
            Assert.AreEqual(expectedQuantity, line.Quantity, "The shopping cart does not contain the expected quantity of the book.");
        }

        [Then(@"my shopping cart should contain (\d+) items in total")]
        public void ThenMyShoppingCartShouldContainItemsInTotal(int expectedQuantity)
        { 
            var controller = GetShoppingCartController();
            var actionResult = controller.Index();

            var shownQuantity = actionResult.Model<ShoppingCart>().Count;

            Assert.AreEqual(expectedQuantity, shownQuantity, "The shopping cart does not contain the expected total quantity of books.");
        }


        [Then(@"my shopping cart should show a total price of (.*)")]
        public void ThenMyShoppingCartShouldShowATotalPriceOf(decimal expectedTotalPrice)
        {
            var controller = GetShoppingCartController();
            var actionResult = controller.Index();

            var shownTotalPrice = actionResult.Model<ShoppingCart>().Price;

            Assert.AreEqual(expectedTotalPrice, shownTotalPrice, "The shopping cart does not contain the expected total price of books.");            
        }

    }
}
