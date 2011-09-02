using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BookShop.AcceptanceTests.Support;
using BookShop.Controllers;
using BookShop.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class HomeSteps
    {
        private ActionResult actionResult;

        [When(@"I enter the shop")]
        public void WhenIEnterTheShop()
        {
            var controller = new HomeController();
            actionResult = controller.Index();
        }

        [Then(@"the home page shows book '(.*)'")]
        public void ThenTheHomePageShowsBook(string title)
        {
            var books = actionResult.Model<List<Book>>();

            CustomAssert.Any(books, b => b.Title == title);
        }

        // this is a helper step for the alternative list-syntax scenario
        [Then(@"the home page shows books (.*)")]
        public void ThenTheHomePageShowsBooks(string titleList)
        {
            var books = actionResult.Model<List<Book>>();

            var titles = titleList.Split(',').Select(t => t.Trim().Trim('\''));
            foreach (var title in titles)
                CustomAssert.Any(books, b => b.Title == title);
            Assert.AreEqual(titles.Count(), books.Count, "The list contains other books too");
        }

        // this is a helper step for the alternative table-syntax scenario
        [Then(@"the home page shows books")]
        public void ThenTheHomePageShowsBooks(Table table)
        {
            var books = actionResult.Model<List<Book>>();

            var titles = table.Rows.Select(r => r["Title"]);
            foreach (var title in titles)
                CustomAssert.Any(books, b => b.Title == title);
            Assert.AreEqual(titles.Count(), books.Count, "The list contains other books too");
        }
    }
}
