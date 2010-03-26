using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BookShop.Models;
using MvcIntegrationTestFramework.Browsing;
using MvcIntegrationTestFramework.Hosting;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BookShop.Specs.Controllers
{
    [Binding]
    public class CatalogSteps
    {
        private static readonly string mvcAppPath = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\..\\BookShop");
        private readonly AppHost appHost = new AppHost(mvcAppPath);
        List<Book> _referenceList = new List<Book>();

        [BeforeScenario]
        public void CleanDB()
        {
            DBHelper.Clean();
            _referenceList.Clear();
        }

        [Given(@"the following books")]
        public void GivenTheFollowingBooks(Table table)
        {
            var db = new BookShopEntities();
            foreach (var row in table.Rows)
            {
                Book book = new Book { Author = row["Author"], Title = row["Title"], Price = Convert.ToDecimal(row["Price"]) };
                _referenceList.Add(book);
                db.AddToBookSet(book);
            }
            db.SaveChanges();
        }

        [When(@"I go to the '(.*)' page")]
        public void WhenISearchForTheTitle(string page)
        {
            appHost.SimulateBrowsingSession(browsingSession => {
                RequestResult result = browsingSession.ProcessRequest("");

                // Can make assertions about the ActionResult...
                var viewResult = (ViewResult)result.ActionExecutedContext.Result;
                Assert.AreEqual("Index", viewResult.ViewName);
                Assert.AreEqual(typeof(List<Book>), viewResult.ViewData.Model.GetType());

                // ... or can make assertions about the rendered HTML
                Assert.IsTrue(result.ResponseText.Contains("<!DOCTYPE html"));

            });
        }
    }
}
