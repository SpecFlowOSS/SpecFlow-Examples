using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShop.Models;
using LinqKit;

namespace BookShop.Controllers
{
    public class CatalogController : Controller
    {
        public ActionResult Search(string searchTerm)
        {
            BookShopEntities db = new BookShopEntities();

            var terms = searchTerm.Split(' ');
            var predicate = PredicateBuilder.False<Book>();
            foreach (string term in terms)
            {
                string temp = term;
                predicate = predicate.Or(p => p.Title.Contains(temp));
                predicate = predicate.Or(p => p.Author.Contains(temp));
            }

            List<Book> books = db.Books.AsExpandable().Where(predicate).OrderBy(b => b.Title).ToList();

            ViewData.Model = books;

            return View("List");
        }

        public ActionResult Details(int id)
        {
            BookShopEntities db = new BookShopEntities();

            var book = db.Books.First(b => b.Id == id);

            ViewData.Model = book;
            return View();
        }
    }
}
