using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShop.Models;

namespace BookShop.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private BookShopEntities _db;

        public HomeController()
        {
            _db = new BookShopEntities();
        }

        public ActionResult Index()
        {
            List<Book> books = _db.BookSet.ToList();
            ViewData.Model = books;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
