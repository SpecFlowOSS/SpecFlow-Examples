using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BookShop.Controllers
{
    using System.Web.Mvc;
    using BookShop.Models;
    using LinqKit;

    public class CatalogController
        : Controller
    {
        public ActionResult Search(string searchTerm)
        {
            using (var db = new BookShopEntities())
            {
                var terms = searchTerm.Split(' ');
                var predicate = PredicateBuilder.New<Book>(false);
                foreach (string term in terms)
                {
                    string temp = term;
                    predicate = predicate.Or(p => p.Title.Contains(temp));
                    predicate = predicate.Or(p => p.Author.Contains(temp));
                }

                List<Book> books = db.Books.AsExpandable().Where(predicate).OrderBy(b => b.Title).ToList();

                this.ViewData.Model = books;

                return this.View("List");
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new BookShopEntities())
            {

                var book = db.Books.First(b => b.Id == id);

                this.ViewData.Model = book;
                return this.View();
            }
        }
    }
}
