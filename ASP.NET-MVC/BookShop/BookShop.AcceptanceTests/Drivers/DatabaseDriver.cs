using BookShop.AcceptanceTests.Drivers.RowObjects;
using BookShop.AcceptanceTests.Support.Database;
using BookShop.Mvc.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BookShop.AcceptanceTests.Drivers
{
    public class DatabaseDriver
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly CatalogContext _catalogContext;

        public DatabaseDriver(DatabaseContext databaseContext, CatalogContext catalogContext)
        {
            _databaseContext = databaseContext;
            _catalogContext = catalogContext;
        }

        private const decimal BookDefaultPrice = 10;

        public void AddToDatabase(Table books)
        {
            var rows = books.CreateSet<BookRow>();


            foreach (var row in rows)
            {
                var book = new Book
                {
                    Author = row.Author ?? "Author",
                    Title = row.Title ?? "Title",
                    Price = row.Price ?? BookDefaultPrice
                };

                _catalogContext.ReferenceBooks.Add(row.Id ?? book.Title, book);

                _databaseContext.Books.Add(book);
            }

            _databaseContext.SaveChanges();
        }
    }
}