using System;
using System.Linq;
using BookShop.AcceptanceTests.Support.Database;
using BookShop.AcceptanceTests.Support.Webserver;
using BookShop.Mvc.Controllers;
using BookShop.Mvc.Logic;
using BookShop.Mvc.Models;
using FluentAssertions;
using Microsoft.Extensions.Configuration;

namespace BookShop.AcceptanceTests.Drivers.Integrated
{
    public class IntegratedShoppingCartDriver : IShoppingCartDriver
    {
        private readonly CatalogContext _catalogContext;
        private readonly IConfiguration _config;
        private readonly DatabaseContext _databaseContext;

        public IntegratedShoppingCartDriver(CatalogContext catalogContext, IConfiguration config, DatabaseContext databaseContext)
        {
            _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
            _config = config;
            _databaseContext = databaseContext;
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
            var book = _catalogContext.ReferenceBooks.GetById(bookTitle);
            using var controller = GetShoppingCartController();
            controller.Add(book.Id);
        }

        public void Delete(string bookTitle)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookTitle);
            using var controller = GetShoppingCartController();
            controller.DeleteItem(book.Id);
        }

        public void SetQuantity(string bookTitle, int quantity)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookTitle);
            using var controller = GetShoppingCartController();
            
            var editArguments = new EditArguments { BookId = book.Id, Quantity = quantity };
            
            controller.Edit(editArguments);
        }

        public void ContainsTypesOfItems(int expectedAmount)
        {
            using var controller = GetShoppingCartController();
            var actionResult = controller.Index();
            actionResult.Model<Mvc.Models.ShoppingCart>().Lines.Should().HaveCount(expectedAmount);
        }

        public void ContainsTotalItems(int expectedQuantity)
        {
            using var controller = GetShoppingCartController();
            var actionResult = controller.Index();
            actionResult.Model<Mvc.Models.ShoppingCart>().Count.Should().Be(expectedQuantity);
        }

        public void ShowsTotalPriceOf(decimal expectedTotalPrice)
        {
            using var controller = GetShoppingCartController();
            var actionResult = controller.Index();
            actionResult.Model<Mvc.Models.ShoppingCart>().Price.Should().Be(expectedTotalPrice);
        }

        public void ContainsCopiesOf(string bookTitle, int expectedQuantity)
        {
            var expectedBook = _catalogContext.ReferenceBooks.GetById(bookTitle);

            using var controller = GetShoppingCartController();
            var actionResult = controller.Index();
            actionResult.Model<Mvc.Models.ShoppingCart>().Lines
                .Should().ContainSingle(ol => ol.Book.Id == expectedBook.Id)
                .Which.Quantity.Should().Be(expectedQuantity);
        }

        private ShoppingCartController GetShoppingCartController()
        {
            var controller = new ShoppingCartController(_databaseContext, new ShoppingCartLogic(_databaseContext));
            HttpContextStub.SetupController(controller);
            return controller;
        }
    }
}
