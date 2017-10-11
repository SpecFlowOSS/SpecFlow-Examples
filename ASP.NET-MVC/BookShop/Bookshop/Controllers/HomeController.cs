namespace BookShop.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using BookShop.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new BookShopEntities())
            {
                List<Book> cheapBooks = db.Books.OrderBy(b => b.Price).Take(3).ToList();
                return this.View(cheapBooks);
            }
        }
    }
}
