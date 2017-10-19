using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BookShop.AcceptanceTests.Common;
using BookShop.AcceptanceTests.Support;
using BookShop.Controllers;
using BookShop.Models;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Drivers.Home
{
    public class HomeDriver
    {
        private ActionResult _result;

        public void Navigate()
        {
            using (var controller = new HomeController())
            {
                this._result = controller.Index();
            }
        }

        public void ShowsBook(string expectedTitle)
        {
            var shownBooks = this._result.Model<List<Book>>();
            BookAssertions.HomeScreenShouldShow(shownBooks, expectedTitle);
        }

        public void ShowsBooks(string expectedTitles)
            => this.ShowsBooks(from t in expectedTitles.Split(',')
                               select t.Trim().Trim('\''));

        public void ShowsBooks(Table expectedBooks)
            => this.ShowsBooks(expectedBooks.Rows.Select(r => r["Title"]));

        public void ShowsBooks(IEnumerable<string> expectedTitles)
        {
            var shownBooks = this._result.Model<List<Book>>();
            BookAssertions.HomeScreenShouldShow(shownBooks, expectedTitles);
        }
    }
}
