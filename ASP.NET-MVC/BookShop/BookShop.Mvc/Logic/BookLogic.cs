using System;
using System.Linq;
using BookShop.Mvc.Models;
using LinqKit;

namespace BookShop.Mvc.Logic
{
    public interface IBookLogic
    {
        Book GetBookById(int id);
        Book[] Search(string searchTerm);
        Book[] FindCheapBooks(int numberOfBooks);
    }

    public class BookLogic : IBookLogic
    {
        private readonly IDatabaseContext _databaseContext;

        public BookLogic(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Book GetBookById(int id)
        {
            return _databaseContext.Books.First(b => b.Id == id);
        }

        public Book[] Search(string searchTerm)
        {
            var terms = searchTerm?.Split(' ') ?? new string[0];
            var predicate = terms.Aggregate(
                PredicateBuilder.New<Book>(string.IsNullOrEmpty(searchTerm)),
                (acc, term) => acc.Or(b => b.Title.Contains(term, StringComparison.InvariantCultureIgnoreCase))
                    .Or(b => b.Author.Contains(term, StringComparison.InvariantCultureIgnoreCase)));

            var books = _databaseContext.Books.AsExpandable()
                .Where(predicate)
                .OrderBy(b => b.Title)
                .ToArray();
            return books;
        }

        public Book[] FindCheapBooks(int numberOfBooks)
        {
            var cheapBooks = _databaseContext.Books.OrderBy(b => b.Price)
                .Take(numberOfBooks)
                .OrderBy(b => b.Title)
                .ToArray();
            return cheapBooks;
        }
    }
}
