using System;
using System.Linq;
using BookShop.AcceptanceTests.Support;
using BookShop.Mvc.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookShop.AcceptanceTests.Drivers.ShoppingCart
{
    public class ShoppingCartDriver
    {
        private readonly CatalogContext _catalogContext;

        public ShoppingCartDriver(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
        }

        public void SetShoppingCart(string bookIds)
        {
            foreach (var bookId in from i in bookIds.Split(',')
                                   select i.Trim().Trim('\''))
            {
                Place(bookId);
            }
        }

        public void Place(string bookId)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookId);
            using (var controller = GetShoppingCartController())
            {
                controller.Add(book.Id);
            }
        }

        public void Delete(string bookId)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookId);
            using (var controller = GetShoppingCartController())
            {
                controller.DeleteItem(book.Id);
            }
        }

        public void SetQuantity(string bookId, int quantity)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookId);
            using (var controller = GetShoppingCartController())
            {
                controller.Edit(new ShoppingCartController.EditArguments { BookId = book.Id, Quantity = quantity });
            }
        }

        public void ContainsTypesOfItems(int expectedAmount)
        {
            using (var controller = GetShoppingCartController())
            {
                var actionResult = controller.Index();
                var foundItemTypeCount = actionResult.Model<Mvc.Models.ShoppingCart>().Lines.Count();

                Assert.AreEqual(
                    expectedAmount,
                    foundItemTypeCount,
                    "The shopping cart does not contain the expected number of item types.");
            }
        }

        public void ContainsTotalItems(int expectedQuantity)
        {
            using (var controller = GetShoppingCartController())
            {
                var actionResult = controller.Index();
                int shownQuantity = actionResult.Model<Mvc.Models.ShoppingCart>().Count;

                Assert.AreEqual(
                    expectedQuantity,
                    shownQuantity,
                    "The shopping cart does not contain the expected total quantity of books.");
            }
        }

        public void ShowsTotalPriceOf(decimal expectedTotalPrice)
        {
            using (var controller = GetShoppingCartController())
            {
                var actionResult = controller.Index();
                var shownTotalPrice = actionResult.Model<Mvc.Models.ShoppingCart>().Price;

                Assert.AreEqual(
                    expectedTotalPrice,
                    shownTotalPrice,
                    "The shopping cart does not contain the expected total price of books.");
            }
        }

        public void ContainsCopiesOf(string bookId, int expectedQuantity)
        {
            var expectedBook = _catalogContext.ReferenceBooks.GetById(bookId);

            using (var controller = GetShoppingCartController())
            {
                var actionResult = controller.Index();
                var line = actionResult.Model<Mvc.Models.ShoppingCart>()
                                       .Lines
                                       .FirstOrDefault(l => l.Book.Id == expectedBook.Id);

                Assert.IsNotNull(line, "The shopping cart does not contain the expected book.");
                Assert.AreEqual(
                    expectedQuantity,
                    line.Quantity,
                    "The shopping cart does not contain the expected quantity of the book.");
            }
        }

        private static ShoppingCartController GetShoppingCartController()
        {
            var controller = new ShoppingCartController();
            HttpContextStub.SetupController(controller);
            return controller;
        }
    }
}
