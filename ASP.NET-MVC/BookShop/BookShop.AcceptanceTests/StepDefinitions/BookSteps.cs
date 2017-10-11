namespace BookShop.AcceptanceTests.StepDefinitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BookShop.AcceptanceTests.Support;
    using BookShop.Controllers;
    using BookShop.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TechTalk.SpecFlow;
    using System.Web.Mvc;

    [Binding]
    public class BookSteps
    {
        private const decimal _bookDefaultPrice = 10;

        private readonly CatalogContext _catalogContext;

        private ActionResult actionResult;

        public BookSteps(CatalogContext catalogContext)
        {
            this._catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
        }

        [Given(@"the following books")]
        public void GivenTheFollowingBooks(Table givenBooks)
        {
            using (var db = new BookShopEntities())
            {
                foreach (var row in givenBooks.Rows)
                {
                    Book book = new Book { Author = row["Author"], Title = row["Title"] };
                    book.Price = givenBooks.Header.Contains("Price")
                               ? Convert.ToDecimal(row["Price"])
                               : _bookDefaultPrice;

                    this._catalogContext.ReferenceBooks.Add(
                        givenBooks.Header.Contains("Id") ? row["Id"] : book.Title,
                        book);

                    db.AddToBooks(book);
                }

                db.SaveChanges();
            }
        }

        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOfBook(string bookId)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookId);

            var controller = new CatalogController();
            actionResult = controller.Details(book.Id);
        }

        [Then(@"the book details should show")]
        public void ThenTheBookDetailsShouldShow(Table expectedBookDetails)
        {
            var shownBookDetails = actionResult.Model<Book>();

            var row = expectedBookDetails.Rows.Single();
            Assert.AreEqual(row["Author"], shownBookDetails.Author, "Book details don't show expected author.");
            Assert.AreEqual(row["Title"], shownBookDetails.Title, "Book details don't show expected title.");
            Assert.AreEqual(Convert.ToDecimal(row["Price"]), shownBookDetails.Price, "Book details don't show expected price.");
        }
    }
}
