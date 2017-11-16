using System.Collections.Generic;
using System.Linq;
using BookShop.Mvc.Models;
using BookShop.WebTests.Selenium.Support;
using FluentAssertions;
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
            var expectedBookList = (from tableRow in table.Rows
                                    let author = tableRow["Author"]
                                    let title = tableRow["Title"]
                                    select new Book {Author = author, Title = title}).ToList();

            int itemCount = selenium.FindElements(By.XPath("//table[@id='searchResultTable']/tbody/tr")).Count;
            var resultBookList = new List<Book>();
            const int headerCount = 0;
            for (int i = headerCount + 1; i <= itemCount; i++)
            {
                string title = selenium.FindElements(By.XPath("//table/tbody/tr[" + i + "]/td[@class='title']")).First().Text;
                string author = selenium.FindElements(By.XPath("//table/tbody/tr[" + i + "]/td[@class='author']")).First().Text;
                resultBookList.Add(new Book { Title = title, Author = author });
            }

            expectedBookList.Select(b => b.Title).Should().Equal(resultBookList.Select(b => b.Title));
        }
    }
}
