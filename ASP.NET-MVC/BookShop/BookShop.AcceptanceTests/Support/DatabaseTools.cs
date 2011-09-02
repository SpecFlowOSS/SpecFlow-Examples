using System;
using System.Linq;
using BookShop.Models;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Support
{
    [Binding]
    public class DatabaseTools
    {
        [BeforeScenario]
        public void CleanDatabase()
        {
            var db = new BookShopEntities();
            foreach (var lineItem in db.OrderLines)
            {
                db.DeleteObject(lineItem);
            }
            foreach (var order in db.Orders)
            {
                db.DeleteObject(order);
            }
            foreach (var book in db.Books)
            {
                db.DeleteObject(book);
            }
            db.SaveChanges();
        }
    }
}
