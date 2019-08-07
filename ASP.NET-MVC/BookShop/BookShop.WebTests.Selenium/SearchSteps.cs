using System.Linq;
using BookShop.Mvc.Models;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using BookShop.AcceptanceTests.Common;
using BookShop.WebTests.Selenium.Drivers;
using BookShop.WebTests.Selenium.Support;

namespace BookShop.WebTests.Selenium
{
    [Binding, Scope(Tag = "web")]
    public class SearchSteps
    {
        private readonly TextBoxDriver _textBoxDriver;
        private readonly NavigationDriver _navDriver;
        private readonly FormDriver _formDriver;
        private readonly SeleniumController _seleniumController;

        public SearchSteps(TextBoxDriver textBoxDriver, NavigationDriver navDriver, 
            FormDriver formDriver, SeleniumController seleniumController)
        {
            _textBoxDriver = textBoxDriver;
            _navDriver = navDriver;
            _formDriver = formDriver;
            _seleniumController = seleniumController;
        }

        [When(@"I search for books by the phrase '(.*)'")]
        public void WhenISearchForBooksByThePhrase(string searchTerm)
        {
            _navDriver.NavigateTo("Home");

            _textBoxDriver.SetTextBoxValue("searchTerm", searchTerm);
            _formDriver.SubmitForm("searchForm");
        }


        [Then(@"the list of found books should contain only: '(.*)'")]
        public void ThenTheListOfFoundBooksShouldContainOnly(string expectedTitleList)
        {
            var expectedTitles = expectedTitleList.Split(',').Select(t => t.Trim().Trim('\''));
            var foundBooks = from row in _seleniumController.WebDriver.FindElements(By.XPath("//table/tbody/tr"))
                             let title = row.FindElement(By.ClassName("title")).Text
                             let author = row.FindElement(By.ClassName("author")).Text
                             select new Book { Title = title, Author = author };

            BookAssertions.FoundBooksShouldMatchTitles(foundBooks, expectedTitles);
        }

        [Then(@"the list of found books should be:")]
        public void ThenTheListOfFoundBooksShouldBe(Table expectedBooks)
        {
            var expectedTitles = expectedBooks.Rows.Select(r => r["Title"]);
            var foundBooks = from row in _seleniumController.WebDriver.FindElements(By.XPath("//table/tbody/tr"))
                             let title = row.FindElement(By.ClassName("title")).Text
                             let author = row.FindElement(By.ClassName("author")).Text
                             select new Book { Title = title, Author = author };

            BookAssertions.FoundBooksShouldMatchTitlesInOrder(foundBooks, expectedTitles);
        }

    }
}