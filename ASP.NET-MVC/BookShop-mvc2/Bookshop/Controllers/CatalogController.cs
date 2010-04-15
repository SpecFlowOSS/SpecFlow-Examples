using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookshop.Models;
using LinqKit;

namespace Bookshop.Controllers
{
    public class CatalogController : Controller
    {
        public ActionResult Search(string searchTerm)
        {
            BookShopEntities db = new BookShopEntities();

//            List<Book> books = db.BookSet.Where(b => b.Title.Contains(searchTerm)).ToList();

            var terms = searchTerm.Split(' ');
            var predicate = PredicateBuilder.False<Book>();
            foreach (string term in terms)
            {
                string temp = term;
                predicate = predicate.Or(p => p.Title.Contains(temp));
            }
            List<Book> books = db.Books.AsExpandable().Where(predicate).ToList();

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
