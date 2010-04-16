using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using BookShop.AcceptanceTests.Support;
using Bookshop.Controllers;
using BookShop.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class ShoppingCartSteps
    {
        private ShoppingCartController GetShoppingCartController()
        {
            var controller = new ShoppingCartController();
            HttpContextStub.SetupController(controller);
            return controller;
        }

        [Given(@"I have a basket with: (.*)")]
        public void PrepareBasket(string bookIdList)
        {
            var bookIds = bookIdList.Split(',');
            foreach (string bookId in bookIds)
            {
                PlaceBookIntoShoppingCart(bookId);
            }
        }

        [When(@"I place (.*) into the basket")]
        public void PlaceBookIntoShoppingCart(string bookId)
        {
            var book = BookSteps.ReferenceBooks.GetById(bookId);

            var controller = GetShoppingCartController();
            controller.Add(book.Id);
        }

        [When(@"I delete (.*) from the basket")]
        public void WhenIDeleteBook1FromTheBasket(string bookId)
        {
            var book = BookSteps.ReferenceBooks.GetById(bookId);

            var controller = GetShoppingCartController();
            controller.DeleteItem(book.Id);
        }

        [When(@"change the quantity of (.*) to ([\d]+)")]
        public void WhenChangeTheQuantityOfABookTo(string bookId, int quantity)
        {
            var book = BookSteps.ReferenceBooks.GetById(bookId);

            var controller = GetShoppingCartController();
            controller.Edit(new ShoppingCartController.EditArguments{BookId = book.Id, Quantity = quantity});
        }

        [Then(@"my shopping cart should contain ([\d]+) items?")]
        public void ThenMyShoppingCartShouldContainLineItems(int count)
        {
            var controller = GetShoppingCartController();
            var actionResult = controller.Index();

            Assert.AreEqual(count, actionResult.Model<ShoppingCart>().Lines.Count(), "Item count in shopping cart is not correct!");
        }

        [Then(@"my basket should contain exactly (\d+) (.*)")]
        public void ThenMyShoppingCartShouldContainBook(int count, string bookId)
        {
            var book = BookSteps.ReferenceBooks.GetById(bookId);

            var controller = GetShoppingCartController();
            var actionResult = controller.Index();

            var line = actionResult.Model<ShoppingCart>().Lines.FirstOrDefault(l => l.Book.Id == book.Id);
            Assert.IsNotNull(line, "The book is not in the basket");
            Assert.AreEqual(count, line.Quantity, "The quantity is not correct!");
        }
    }
}
