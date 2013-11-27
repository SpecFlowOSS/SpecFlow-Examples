using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

using BookShop.AcceptanceTests.Common;
using BookShop.AcceptanceTests.Support;
using BookShop.Controllers;
using BookShop.Models;

namespace BookShop.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class SearchSteps
    {
        private ActionResult actionResult;

        [When(@"A step definition without usage")]
        public void AStepDefinitionWithoutUsage()
        { 
        }

        [When(@"I search for books by the phrase '(.*)'")]
        public void WhenISearchForBooksByThePhrase(string searchTerm)
        {
            var controller = new CatalogController();
            actionResult = controller.Search(searchTerm);
        }

        [Then(@"the list of found books should contain only: (.*)")]
        public void ThenTheListOfFoundBooksShouldContainOnly(string expectedTitleList)
        {
            var foundBooks = actionResult.Model<List<Book>>();

            var expectedTitles = expectedTitleList.Split(',').Select(t => t.Trim().Trim('\''));

            BookAssertions.FoundBooksShouldMatchTitles(foundBooks, expectedTitles);       
        }

        [Then(@"the list of found books should be:")]
        public void ThenTheListOfFoundBooksShouldBe(Table expectedBooks)
        {
            var foundBooks = actionResult.Model<List<Book>>();

            var expectedTitles = expectedBooks.Rows.Select(r => r["Title"]);

            BookAssertions.FoundBooksShouldMatchTitlesInOrder(foundBooks, expectedTitles);
        }

    }
}
