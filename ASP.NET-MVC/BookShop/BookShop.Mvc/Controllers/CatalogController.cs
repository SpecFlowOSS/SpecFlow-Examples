using BookShop.Mvc.Logic;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Mvc.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IBookLogic _bookLogic;

        public CatalogController(IBookLogic bookLogic)
        {
            _bookLogic = bookLogic;
        }

        public ActionResult Search(string searchTerm)
        {
            var books =  _bookLogic.Search(searchTerm);

            return View("List", books);
        }

       

        public ActionResult Details(int id)
        {
            var book = _bookLogic.GetBookById(id);
            return View(book);
        }

        
    }
}