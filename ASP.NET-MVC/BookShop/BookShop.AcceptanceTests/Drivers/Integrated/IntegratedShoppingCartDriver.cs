using System;
using System.Linq;
using BookShop.AcceptanceTests.Support;
using BookShop.Mvc.Controllers;
using BookShop.Mvc.Models;
using FluentAssertions;
using Microsoft.Extensions.Configuration;

namespace BookShop.AcceptanceTests.Drivers.Integrated
{
    public class IntegratedShoppingCartDriver : IShoppingCartDriver
    {
        private readonly CatalogContext _catalogContext;
        private readonly IConfiguration _config;

        public IntegratedShoppingCartDriver(CatalogContext catalogContext, IConfiguration config)
        {
            _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
            _config = config;
        }

        public void SetShoppingCart(string bookIds)
        {
            foreach (string bookId in from i in bookIds.Split(',')
                                      select i.Trim().Trim('\''))
            {
                Place(bookId);
            }
        }

        public void Place(string bookId)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookId);
            using var controller = GetShoppingCartController(_config);
            controller.Add(book.Id);
        }

        public void Delete(string bookId)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookId);
            using var controller = GetShoppingCartController(_config);
            controller.DeleteItem(book.Id);
        }

        public void SetQuantity(string bookId, int quantity)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookId);
            using var controller = GetShoppingCartController(_config);
            controller.Edit(new ShoppingCartController.EditArguments { BookId = book.Id, Quantity = quantity });
        }

        public void ContainsTypesOfItems(int expectedAmount)
        {
            using var controller = GetShoppingCartController(_config);
            var actionResult = controller.Index();
            actionResult.Model<Mvc.Models.ShoppingCart>().Lines.Should().HaveCount(expectedAmount);
        }

        public void ContainsTotalItems(int expectedQuantity)
        {
            using var controller = GetShoppingCartController(_config);
            var actionResult = controller.Index();
            actionResult.Model<Mvc.Models.ShoppingCart>().Count.Should().Be(expectedQuantity);
        }

        public void ShowsTotalPriceOf(decimal expectedTotalPrice)
        {
            using var controller = GetShoppingCartController(_config);
            var actionResult = controller.Index();
            actionResult.Model<Mvc.Models.ShoppingCart>().Price.Should().Be(expectedTotalPrice);
        }

        public void ContainsCopiesOf(string bookId, int expectedQuantity)
        {
            var expectedBook = _catalogContext.ReferenceBooks.GetById(bookId);

            using var controller = GetShoppingCartController(_config);
            var actionResult = controller.Index();
            actionResult.Model<Mvc.Models.ShoppingCart>().Lines
                .Should().ContainSingle(ol => ol.Book.Id == expectedBook.Id)
                .Which.Quantity.Should().Be(expectedQuantity);
        }

        private static ShoppingCartController GetShoppingCartController(IConfiguration config)
        {
            var controller = new ShoppingCartController(new DatabaseContext());
            HttpContextStub.SetupController(controller);
            return controller;
        }
    }
}
