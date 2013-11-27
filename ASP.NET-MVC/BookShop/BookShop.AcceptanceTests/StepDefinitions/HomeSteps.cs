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
using BookShop.AcceptanceTests.Common;

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

        [Then(@"the home screen should show the book '(.*)'")]
        public void ThenTheHomeScreenShouldShowTheBook(string expectedTitle)
        {
            var shownBooks = actionResult.Model<List<Book>>();

            BookAssertions.HomeScreenShouldShow(shownBooks, expectedTitle);
        }

        [Then(@"the home screen should show the books (.*)")]
        public void ThenTheHomeScreenShouldShowTheBooks(string expectedTitleList)
        {
            var shownBooks = actionResult.Model<List<Book>>();
            var expectedTitles = expectedTitleList.Split(',').Select(t => t.Trim().Trim('\''));

            BookAssertions.HomeScreenShouldShow(shownBooks, expectedTitles);
        }

        [Then(@"the home screen should show the following books")]
        public void ThenTheHomeScreenShouldShowTheFollowingBooks(Table expectedBooks)
        {
            var shownBooks = actionResult.Model<List<Book>>();
            var expectedTitles = expectedBooks.Rows.Select(r => r["Title"]);

            BookAssertions.HomeScreenShouldShow(shownBooks, expectedTitles);
         }

    }
}
