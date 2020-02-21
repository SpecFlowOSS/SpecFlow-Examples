using BookShop.Mvc.Models;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Support
{
    [Binding]
    public class DatabaseTools
    {
        private readonly IConfiguration _config;

        public DatabaseTools(IConfiguration config)
        {
            _config = config;
        }

        [BeforeScenario(Order = 100)]
        public void CleanDatabase()
        {
            using var db = new DatabaseContext(_config);
            db.Database.EnsureCreated();
            
            db.OrderLines.RemoveRange(db.OrderLines);
            db.Orders.RemoveRange(db.Orders);
            db.Books.RemoveRange(db.Books);
            db.SaveChanges();
        }
    }
}
