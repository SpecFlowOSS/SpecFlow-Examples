using BookShop.Mvc.Logic;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Mvc.Controllers
{
    public class HomeController
        : Controller
    {
        private readonly IBookLogic _bookLogic;

        public HomeController(IBookLogic bookLogic)
        {
            _bookLogic = bookLogic;
        }

        public ActionResult Index()
        {
            var cheapBooks = _bookLogic.FindCheapBooks(3);
            return View(cheapBooks);
        }

        public ActionResult Privacy()
        {
            return View();
        }
    }
}