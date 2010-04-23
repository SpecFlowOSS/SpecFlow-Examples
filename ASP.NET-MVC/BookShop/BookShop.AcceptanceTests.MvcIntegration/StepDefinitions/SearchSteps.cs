using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BookShop.AcceptanceTests.MvcIntegration.Support;
using BookShop.AcceptanceTests.Support;
using Bookshop.Controllers;
using Bookshop.Models;
using MvcIntegrationTestFramework.Browsing;
using MvcIntegrationTestFramework.Hosting;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.MvcIntegration.StepDefinitions
{
    [Binding]
    public class SearchSteps 
    {
        private static readonly string mvcAppPath = ConfigurationManager.AppSettings["AppFolder"];
        private readonly AppHost appHost = new AppHost(mvcAppPath);

        private HostedViewResult<List<Book>> actionResult;

        [When(@"I perform a simple search on '(.*)'")]
        public void PerformSimpleSearch(string title)
        {
            actionResult = appHost.SimulateBrowsingSession(browsingSession =>
                                                               {
                                                                   RequestResult result = browsingSession.ProcessRequest("Catalog/Search?searchTerm=" + title);

                                                                   var currentActionResult = result.ActionExecutedContext.Result;
                                                                   return new HostedViewResult<List<Book>>(result.ResponseText, currentActionResult.Model<List<Book>>());
                                                               });
        }

        [Then(@"the book list should exactly contain book '(.*)'")]
        public void ThenTheBookListShouldExactlyContainBook(string title)
        {
            ThenTheBookListShouldExactlyContainBooks(title);
        }

        [Then(@"the book list should exactly contain books (.*)")]
        public void ThenTheBookListShouldExactlyContainBooks(string titleList)
        {
            var books = actionResult.Model;

            var titles = titleList.Split(',').Select(t => t.Trim().Trim('\''));
            foreach (var title in titles)
                CustomAssert.Any(books, b => b.Title == title);
            Assert.AreEqual(titles.Count(), books.Count, "The list contains other books too");

            foreach (var book in books)
            {
                // you can make assertions for the HTML result as well:
                StringAssert.Contains("Catalog/Details/" + book.Id, actionResult.ResponseText);
            }
        }
    }
}