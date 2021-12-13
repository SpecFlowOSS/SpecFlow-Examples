using DemoWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", userModel);
            }

            return RedirectToAction("LandingPage", userModel);
        }

        public IActionResult LandingPage(UserModel userModel) 
        {
            return this.View(userModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}