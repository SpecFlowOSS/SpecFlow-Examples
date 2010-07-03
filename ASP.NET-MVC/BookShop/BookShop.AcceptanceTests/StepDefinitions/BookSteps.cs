using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BookShop.AcceptanceTests.Support;
using Bookshop.Controllers;
using Bookshop.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class BookSteps
    {
        private readonly CatalogContext _catalogContext;

        public BookSteps(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        [Given(@"the following books")]
        public void GivenTheFollowingBooks(Table table)
        {
            var db = new BookShopEntities();
            foreach (var row in table.Rows)
            {
                Book book = new Book { Author = row["Author"], Title = row["Title"], Price = Convert.ToDecimal(row["Price"]) };
                if (table.Header.Contains("Id"))
                    _catalogContext.ReferenceBooks.Add(row["Id"], book);
                db.AddToBooks(book);
            }
            db.SaveChanges();
        }

        private ActionResult actionResult;

        [When(@"I open the details of (.*)")]
        public void WhenIOpenTheDetailsOfBook(string bookId)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookId);

            var controller = new CatalogController();
            actionResult = controller.Details(book.Id);
        }

        [Then(@"the book details shows")]
        public void ThenTheBookDetailsShows(Table table)
        {
            var book = actionResult.Model<Book>();

            var row = table.Rows.Single();
            Assert.AreEqual(row["Author"], book.Author);
            Assert.AreEqual(row["Title"], book.Title);
            Assert.AreEqual(Convert.ToDecimal(row["Price"]), book.Price);
        }
    }
}
