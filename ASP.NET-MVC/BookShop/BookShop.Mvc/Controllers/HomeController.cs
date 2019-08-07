using System.Linq;
using BookShop.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Mvc.Controllers
{
    public class HomeController
        : Controller
    {
        private readonly IDatabaseContext _databaseContext;

        public HomeController(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public ActionResult Index()
        {
            var cheapBooks = _databaseContext.Books.OrderBy(b => b.Price)
                             .Take(3)
                             .OrderBy(b => b.Title)
                             .ToArray();
            return View(cheapBooks);
        
        }

        public ActionResult Privacy()
        {
            return View();
        }
    }
}