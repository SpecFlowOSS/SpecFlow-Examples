using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BookShop.AcceptanceTests.Support;
using Bookshop.Controllers;
using Bookshop.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class SearchSteps
    {
        private ActionResult actionResult;

        [When(@"I perform a simple search on '(.*)'")]
        public void WhenIPerformASimpleSearchOn(string searchTerm)
        {
            var controller = new CatalogController();
            actionResult = controller.Search(searchTerm);
        }

        [Then(@"the book list should exactly contain book '(.*)'")]
        public void ThenTheBookListShouldExactlyContainBook(string title)
        {
            // stand-alone implementation
            // var books = actionResult.Model<List<Book>>();
            // CustomAssert.Any(books, b => b.Title == title);
            // Assert.AreEqual(1, books.Count, "The list contains other books too");

            ThenTheBookListShouldExactlyContainBooks(title);
        }

        [Then(@"the book list should exactly contain books (.*)")]
        public void ThenTheBookListShouldExactlyContainBooks(string titleList)
        {
            var books = actionResult.Model<List<Book>>();

            var titles = titleList.Split(',').Select(t => t.Trim().Trim('\''));
            foreach (var title in titles)
                CustomAssert.Any(books, b => b.Title == title);
            Assert.AreEqual(titles.Count(), books.Count, "The list contains other books too");
        }
    }
}
