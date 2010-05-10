using System.Collections.Generic;
using System.Linq;
using BookShop.AcceptanceTests.Support;
using BookShop.AcceptanceTests.WatiN.Support;
using Bookshop.Models;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace BookShop.AcceptanceTests.WatiN.StepDefinitions
{
    [Binding]
    public class SearchSteps 
    {
        [When(@"I perform a simple search on '(.*)'")]
        public void PerformSimpleSearch(string title)
        {
            WebBrowser.Current.GoToThePage("Home");
            WebBrowser.Current.TextFields.First(Find.ById("searchTerm")).TypeText(title);
            WebBrowser.Current.Buttons.First(Find.ByValue("Search")).Click();
            //WebBrowser.Current.WaitForPageToLoad("30000");
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

            var table = WebBrowser.Current.Tables.First();
            var itemCount = table.TableRows.Count;
            var books = new List<Book>();
            const int headerCount = 1;
            for (int i = headerCount; i < itemCount; i++)
            {
                var tableRow = table.TableRows[i];
                string title = tableRow.TableCells.First(Find.ByClass("title")).Text;
                string author = tableRow.TableCells.First(Find.ByClass("author")).Text;
                books.Add(new Book { Title = title, Author = author });
            }

            foreach (var title in titles)
                CustomAssert.Any(books, b => b.Title == title);
            Assert.AreEqual(titles.Count(), books.Count, "The list contains other books too");
        }
    }
}