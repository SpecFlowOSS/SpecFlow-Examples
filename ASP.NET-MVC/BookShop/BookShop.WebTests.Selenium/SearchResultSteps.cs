using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShop.Models;
using BookShop.WebTests.Selenium.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BookShop.WebTests.Selenium
{
    [Binding, Scope(Tag = "web")]
    public class SearchResultSteps : SeleniumStepsBase
    {
        [When(@"I sort the search result table by Author")]
        public void WhenISortTheSearchResultTableByAuthor()
        {
            selenium.FindElements(By.XPath("//table[@id='searchResultTable']/thead/tr/th[text()='Author']")).First().Click();
        }

        [When(@"I sort the search result table by Title")]
        public void WhenISortTheSearchResultTableByTitle()
        {
            selenium.FindElements(By.XPath("//table[@id='searchResultTable']/thead/tr/th[text()='Title']")).First().Click();
        }

        [Then(@"the search result list should display the books in the following order")]
        public void ThenTheSearchResultListShouldDisplayTheBooksInTheFollowingOrder(Table table)
        {
            var expectedBookList = new List<Book>();

            foreach (var tableRow in table.Rows)
            {
                var author = tableRow["Author"];
                var title = tableRow["Title"];

                var book = new Book { Author = author, Title = title };
                expectedBookList.Add(book);
            }

            var itemCount = selenium.FindElements(By.XPath("//table[@id='searchResultTable']/tbody/tr")).Count();
            var resultBookList = new List<Book>();
            const int headerCount = 0;
            for (int i = headerCount + 1; i <= itemCount; i++)
            {
                string title = selenium.FindElements(By.XPath("//table/tbody/tr[" + i + "]/td[@class='title']")).First().Text;
                string author = selenium.FindElements(By.XPath("//table/tbody/tr[" + i + "]/td[@class='author']")).First().Text;
                resultBookList.Add(new Book { Title = title, Author = author });
            }

            var expextedTitleList = expectedBookList.Select(ebl => ebl.Title).ToList();
            var resultTitleList = resultBookList.Select(ral => ral.Title).ToList();

            CollectionAssert.AreEqual(expextedTitleList, resultTitleList);
        }
    }
}
