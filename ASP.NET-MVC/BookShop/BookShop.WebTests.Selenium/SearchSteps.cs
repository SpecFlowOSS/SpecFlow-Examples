using System.Collections.Generic;
using System.Linq;
using BookShop.Models;
using BookShop.WebTests.Selenium.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BookShop.WebTests.Selenium
{
    [Binding, StepScope(Tag = "web")]
    public class SearchSteps : SeleniumStepsBase
    {
        [When(@"I perform a simple search on '(.*)'")]
        [Given(@"I perform a simple search on '(.*)'")]
        public void PerformSimpleSearch(string title)
        {
            selenium.NavigateTo("Home");

            selenium.SetTextBoxValue("searchTerm", title);
            selenium.SubmitForm("searchForm");
        }

        [Then(@"the book list should exactly contain book '(.*)'")]
        public void ThenTheBookListShouldExactlyContainBook(string title)
        {
            ThenTheBookListShouldExactlyContainBooks(title);
        }

        [Then(@"the book list should exactly contain books (.*)")]
        public void ThenTheBookListShouldExactlyContainBooks(string titleList)
        {
            var titles = titleList.Split(',').Select(t => t.Trim().Trim('\''));

            var books = selenium.FindElements(By.XPath("//table/tbody/tr"))
                .Select(row => new Book()
                {
                    Title = row.FindElement(By.ClassName("title")).Text,
                    Author = row.FindElement(By.ClassName("author")).Text,
                }).ToList();

            
            CollectionAssert.AreEquivalent(titles.ToList(), books.Select(b => b.Title).ToList(), "Search result is different from expected");
        }
    }
}