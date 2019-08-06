using System;
using System.Linq;
using BookShop.AcceptanceTests.Support;
using BookShop.Mvc.Controllers;
using BookShop.Mvc.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Drivers.BookDetails
{
    public class BookDetailsDriver
    {
        private const decimal BookDefaultPrice = 10;
        private readonly IDatabaseContext _databaseContext;
        private readonly CatalogContext _context;
        private ActionResult _result;

        public BookDetailsDriver(CatalogContext context, DatabaseContext databaseContext)
        {
            _context = context;
            _databaseContext = databaseContext;
        }

        public void AddToDatabase(Table books)
        {
            foreach (var row in books.Rows)
            {
                var book = new Book
                {
                    Author = row["Author"],
                    Title = row["Title"],
                    Price = books.Header.Contains("Price")
                        ? Convert.ToDecimal(row["Price"])
                        : BookDefaultPrice
                };

                _context.ReferenceBooks.Add(
                    books.Header.Contains("Id") ? row["Id"] : book.Title,
                    book);

                _databaseContext.Books.Add(book);
            }

            _databaseContext.SaveChanges();
        }

        public void OpenBookDetails(string bookId)
        {
            var book = _context.ReferenceBooks.GetById(bookId);
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
