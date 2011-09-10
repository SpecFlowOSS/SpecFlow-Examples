using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShop.Models;

namespace BookShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BookShopEntities db = new BookShopEntities();

            List<Book> cheapBooks = db.Books.OrderBy(b => b.Price).Take(3).ToList();

            return View(cheapBooks);
        }
    }
}
