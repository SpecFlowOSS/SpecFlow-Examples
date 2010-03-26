using System;
using System.Collections.Generic;
using System.Linq;
using BookShop.Models;
using NUnit.Framework;
using Selenium;
using TechTalk.SpecFlow;

namespace BookShop.Specs.Web
{
    [Binding]
    public class CatalogSteps
    {
        private readonly ISelenium _selenium;
        private readonly SeleniumSteps _seleniumSteps;
        public readonly Dictionary<string, Book> ReferenceBooks = new Dictionary<string, Book>();

        public CatalogSteps(SeleniumContext seleniumContext)
        {
            _selenium = seleniumContext.Selenium;
            _seleniumSteps = new SeleniumSteps(seleniumContext);
        }

        [BeforeScenario]
        public void CleanDB()
        {
            DBHelper.Clean();
            ReferenceBooks.Clear();
        }

        [Given(@"the following books")]
        public void GivenTheFollowingBooks(Table table)
        {
            var db = new BookShopEntities();
            foreach (var row in table.Rows)
            {
                Book book = new Book { Author = row["Author"], Title = row["Title"], Price = Convert.ToDecimal(row["Price"]) };
                ReferenceBooks.Add(row["Id"], book);
                db.AddToBookSet(book);
            }
            db.SaveChanges();
        }

        [When(@"I perform a simple search on '(.*)'")]
        public void PerformSimpleSearch(string title)
        {
            _seleniumSteps.GoToThePage("Catalog");
            _selenium.Type("searchTerm", title);
            _selenium.Click("searchButton");
            _selenium.WaitForPageToLoad("30000");
        }

        [Then(@"the book list should exactly contain: (.*)")]
        public void Titles_Should_Contain(string bookIdList)
        {
            var itemCount =_selenium.GetXpathCount("//table/tbody/tr");
            var books = new List<Book>();
            for (int i = 1; i <= itemCount; i++)
            {
                string title = _selenium.GetText("//table/tbody/tr[" + i + "]/td[@class='title']");
                string author = _selenium.GetText("//table/tbody/tr[" + i + "]/td[@class='author']");
                books.Add(new Book { Title=title, Author=author});
            }

            var bookIds = bookIdList.Split(',');
            Assert.AreEqual(bookIds.Length, books.Count, "The book list has not the expected result count!");
            foreach (string bookId in bookIds)
            {
                var referenceBookEntry = ReferenceBooks.Where(p => p.Key == bookId.Trim()).Single();
                var referenceBook = referenceBookEntry.Value;
                Assert.IsTrue(books.Any(b => b.Title == referenceBook.Title));
            }
        }

        [Then(@"the book-list should contain (\d) elements?")]
        public void ThenTheBook_ListShouldContainElements(int count)
        {
            Assert.AreEqual(count, _selenium.GetXpathCount("//div[@class='item']"));
        }

        [Then(@"the book details should be displayed")]
        public void CheckBookDetails()
        {
            Assert.IsTrue(_selenium.IsTextPresent("Title"));
            Assert.IsTrue(_selenium.IsTextPresent("Author"));
        }
    }
}
