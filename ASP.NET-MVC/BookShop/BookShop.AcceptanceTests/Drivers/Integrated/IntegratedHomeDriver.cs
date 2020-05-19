using System;
using System.Collections.Generic;
using System.Linq;
using BookShop.AcceptanceTests.Common;
using BookShop.AcceptanceTests.Support;
using BookShop.Mvc.Controllers;
using BookShop.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Drivers.Integrated
{
    public class IntegratedHomeDriver : IHomeDriver
    {
        private readonly IDatabaseContext _databaseContext;
        private ActionResult? _result = null;

        public IntegratedHomeDriver(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Navigate()
        {
            using var controller = new HomeController(_databaseContext);
            _result = controller.Index();
        }

        public void ShowsBook(string expectedTitle)
        {
            if (_result == null) throw new NullReferenceException(nameof(_result));

            var shownBooks = _result.Model<IEnumerable<Book>>();
            BookAssertions.HomeScreenShouldShow(shownBooks, expectedTitle);
        }

        public void ShowsBooks(string expectedTitles)
            => ShowsBooks(from t in expectedTitles.Split(',')
                          select t.Trim().Trim('\''));

        public void ShowsBooks(Table expectedBooks)
            => ShowsBooks(expectedBooks.Rows.Select(r => r["Title"]));

        public void ShowsBooks(IEnumerable<string> expectedTitles)
        {
            if (_result == null) throw new NullReferenceException(nameof(_result));

            var shownBooks = _result.Model<IEnumerable<Book>>();
            BookAssertions.HomeScreenShouldShow(shownBooks, expectedTitles);
        }
    }
}
