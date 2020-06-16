using BookShop.Mvc.Models;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Support.Database
{
    [Binding]
    public class DatabaseTools
    {
        private readonly DatabaseContext _databaseContext;

        public DatabaseTools(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [BeforeScenario(Order = 100)]
        public void CleanDatabase()
        {
            _databaseContext.Database.EnsureCreated();

            _databaseContext.OrderLines.RemoveRange(_databaseContext.OrderLines);
            _databaseContext.Orders.RemoveRange(_databaseContext.Orders);
            _databaseContext.Books.RemoveRange(_databaseContext.Books);
            _databaseContext.SaveChanges();

        }
    }
}
