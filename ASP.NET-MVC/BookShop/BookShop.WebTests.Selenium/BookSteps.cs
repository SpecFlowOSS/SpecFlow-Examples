using System;
using BookShop.AcceptanceTests.Support;
using BookShop.Models;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.StepDefinitions
{
    [Binding, StepScope(Tag = "web")]
    public class BookSteps
    {
        private readonly CatalogContext _catalogContext;

        public BookSteps(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        [Given(@"the following books")]
        public void GivenTheFollowingBooks(Table table)
        {
            var db = new BookShopEntities();
            foreach (var row in table.Rows)
            {
                Book book = new Book { Author = row["Author"], Title = row["Title"], Price = Convert.ToDecimal(row["Price"]) };
                if (table.Header.Contains("Id"))
                    _catalogContext.ReferenceBooks.Add(row["Id"], book);
                db.AddToBooks(book);
            }
            db.SaveChanges();
        }

    }
}
