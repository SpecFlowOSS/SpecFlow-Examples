using System;
using System.Linq;
using System.Web.Mvc;
using BookShop.AcceptanceTests.Support;
using BookShop.Controllers;
using BookShop.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Drivers.BookDetails
{

    public class BookDetailsDriver
    {
        private const decimal BookDefaultPrice = 10;
        private readonly CatalogContext _context;
        private ActionResult _result;

        public BookDetailsDriver(CatalogContext context)
        {
            this._context = context;
        }

        public void AddToDatabase(Table books)
        {
            using (var db = new BookShopEntities())
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

                    this._context.ReferenceBooks.Add(
                        books.Header.Contains("Id") ? row["Id"] : book.Title,
                        book);

                    db.AddToBooks(book);
                }

                db.SaveChanges();
            }
        }

        public void OpenBookDetails(string bookId)
        {
            var book = this._context.ReferenceBooks.GetById(bookId);
            using (var controller = new CatalogController())
            {
                this._result = controller.Details(book.Id);
            }
        }

        public void ShowsBookDetails(Table expectedBookDetails)
        {
            var shownBookDetails = this._result.Model<Book>();

            var row = expectedBookDetails.Rows.Single();
            Assert.AreEqual(row["Author"], shownBookDetails.Author, "Book details don't show expected author.");
            Assert.AreEqual(row["Title"], shownBookDetails.Title, "Book details don't show expected title.");
            Assert.AreEqual(Convert.ToDecimal(row["Price"]), shownBookDetails.Price, "Book details don't show expected price.");
        }
    }
}
