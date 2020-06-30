using System.Linq;
using BookShop.AcceptanceTests.Support.Database;
using BookShop.Mvc.Controllers;
using BookShop.Mvc.Logic;
using BookShop.Mvc.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Drivers.Integrated
{
    public class IntegratedBookDetailsDriver : IBookDetailsDriver
    {
        private readonly CatalogContext _catalogContext;
        private readonly BookLogic _bookLogic;
        private ActionResult _result = null;

        public IntegratedBookDetailsDriver(CatalogContext catalogContext, BookLogic bookLogic)
        {
            _catalogContext = catalogContext;
            _bookLogic = bookLogic;
        }


        public void OpenBookDetails(string bookTitle)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookTitle);
            using var controller = new CatalogController(_bookLogic);
            _result = controller.Details(book.Id);
        }

        public void ShowsBookDetails(Table expectedBookDetails)
        {
            var shownBookDetails = _result.Model<Book>();
            var row = expectedBookDetails.Rows.Single();
            
            shownBookDetails.Should().Match<Book>(
                b => b.Title == row["Title"]
                && b.Author == row["Author"]
                && b.Price == decimal.Parse(row["Price"]));
        }
    }
}
