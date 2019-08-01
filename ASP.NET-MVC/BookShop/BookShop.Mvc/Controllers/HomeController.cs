using System.Linq;
using BookShop.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Mvc.Controllers
{
    public class HomeController
        : Controller
    {
        public ActionResult Index()
        {
            using (var db = new DatabaseContext())
            {
                var cheapBooks = db.Books.OrderBy(b => b.Price)
                                         .Take(3)
                                         .OrderBy(b => b.Title)
                                         .ToArray();
                return View(cheapBooks);
            }
        }

        public ActionResult Privacy()
        {
            return View();
        }
    }
}