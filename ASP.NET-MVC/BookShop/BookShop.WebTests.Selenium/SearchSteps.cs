using System.Collections.Generic;
using System.Linq;
using BookShop.Models;
using BookShop.WebTests.Selenium.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using BookShop.AcceptanceTests.Common;

namespace BookShop.WebTests.Selenium
{
    [Binding, Scope(Tag = "web")]
    public class SearchSteps : SeleniumStepsBase
    {

        [When(@"I search for books by the phrase '(.*)'")]
        public void WhenISearchForBooksByThePhrase(string searchTerm)
        {
            selenium.NavigateTo("Home");

            selenium.SetTextBoxValue("searchTerm", searchTerm);
            selenium.SubmitForm("searchForm");
        }


        [Then(@"the list of found books should contain only: '(.*)'")]
        public void ThenTheListOfFoundBooksShouldContainOnly(string expectedTitleList)
        {

            var foundBooks = selenium.FindElements(By.XPath("//table/tbody/tr"))
                .Select(row => new Book()
                {
                    Title = row.FindElement(By.ClassName("title")).Text,
                    Author = row.FindElement(By.ClassName("author")).Text,
                }).ToList();

            var expectedTitles = expectedTitleList.Split(',').Select(t => t.Trim().Trim('\''));

            BookAssertions.FoundBooksShouldMatchTitles(foundBooks, expectedTitles);
        }

        [Then(@"the list of found books should be:")]
        public void ThenTheListOfFoundBooksShouldBe(Table expectedBooks)
        {
            var foundBooks = selenium.FindElements(By.XPath("//table/tbody/tr"))
                .Select(row => new Book()
                {
                    Title = row.FindElement(By.ClassName("title")).Text,
                    Author = row.FindElement(By.ClassName("author")).Text,
                }).ToList();

            var expectedTitles = expectedBooks.Rows.Select(r => r["Title"]);

            BookAssertions.FoundBooksShouldMatchTitlesInOrder(foundBooks, expectedTitles);
        }

    }
}