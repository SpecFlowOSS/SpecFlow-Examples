using System;
using System.Linq;
using BookShop.Mvc.Models;
using LinqKit;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Mvc.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IDatabaseContext _databaseContext;

        public CatalogController(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public ActionResult Search(string searchTerm)
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

            return View("List", books);
        }

        public ActionResult Details(int id)
        {
            var book = _databaseContext.Books.First(b => b.Id == id);
            return View(book);
        }
    }
}