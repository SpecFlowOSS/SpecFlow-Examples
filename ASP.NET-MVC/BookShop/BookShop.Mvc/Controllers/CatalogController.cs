using System.Linq;
using System.Web.Mvc;
using BookShop.Mvc.Models;
using LinqKit;

namespace BookShop.Mvc.Controllers
{
    public class CatalogController : Controller
    {
        public ActionResult Search(string searchTerm)
        {
            using (var db = new DatabaseContext())
            {
                var terms = searchTerm?.Split(' ') ?? new string[0];
                var predicate = PredicateBuilder.New<Book>(searchTerm is null);
                foreach (string term in terms)
                {
                    string temp = term;
                    predicate = predicate.Or(p => p.Title.Contains(temp));
                    predicate = predicate.Or(p => p.Author.Contains(temp));
                }

                var books = db.Books.AsExpandable().Where(predicate).OrderBy(b => b.Title).ToArray();
                return View("List", books);
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new DatabaseContext())
            {

                var book = db.Books.First(b => b.Id == id);
                return View(book);
            }
        }
    }
}