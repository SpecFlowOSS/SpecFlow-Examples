using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShop.Models;
using LinqKit;

namespace BookShop.Controllers
{
    [HandleError]
    public class CatalogController : Controller
    {
        private BookShopEntities _db = Database.Instance;

        public ActionResult Index()
        {
            List<Book> books = _db.BookSet.ToList();
            ViewData.Model = books;

            return View();
        }

        public ActionResult List(string searchTerm)
        {
//            List<Book> books = _db.BookSet.Where(b => b.Title.Contains(searchTerm)).ToList();

            var terms = searchTerm.Split(' ');
            var predicate = PredicateBuilder.False<Book>();
            foreach (string term in terms)
            {
                string temp = term;
                predicate = predicate.Or(p => p.Title.Contains(temp));
            }
            List<Book> books = _db.BookSet.AsExpandable().Where(predicate).ToList();
            
            ViewData.Model = books;

            return View();
        }     
        
        public ActionResult Detail(int id)
        {
            Book book = _db.BookSet.Where(b => b.Id == id).First();
            ViewData.Model = book;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
