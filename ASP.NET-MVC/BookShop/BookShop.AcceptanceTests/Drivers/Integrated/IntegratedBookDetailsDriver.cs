using System.Linq;
using BookShop.AcceptanceTests.Support;
using BookShop.Mvc.Controllers;
using BookShop.Mvc.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Drivers.Integrated
{
    public class IntegratedBookDetailsDriver : IBookDetailsDriver
    {
        private readonly CatalogContext _catalogContext;
        private readonly DatabaseContext _databaseContext;
        private ActionResult? _result = null;

        public IntegratedBookDetailsDriver(CatalogContext catalogContext, DatabaseContext databaseContext)
        {
            _catalogContext = catalogContext;
            _databaseContext = databaseContext;
        }


        public void OpenBookDetails(string bookTitle)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookTitle);
            using var controller = new CatalogController(_databaseContext);
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
