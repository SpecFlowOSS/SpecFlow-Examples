using BookShop.Mvc.Logic;
using BookShop.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Mvc.Controllers
{
    public class ShoppingCartController
        : Controller
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly IShoppingCartLogic _shoppingCartLogic;


        public ShoppingCartController(IDatabaseContext databaseContext, IShoppingCartLogic shoppingCartLogic)
        {
            _databaseContext = databaseContext;
            _shoppingCartLogic = shoppingCartLogic;
        }

        public ActionResult Index()
        {
            var shoppingCart = _shoppingCartLogic.GetShoppingCart(HttpContext.Session);
            return View(shoppingCart);
        }

        public ActionResult Add(int bookId)
        {
            var shoppingCart = _shoppingCartLogic.GetShoppingCart(HttpContext.Session);

            ViewData.Model = _shoppingCartLogic.AddBookToCart(HttpContext.Session,bookId, shoppingCart);
            return RedirectToAction(nameof(Index));
        }

       

        [HttpGet]
        public ActionResult DeleteItem(int id)
        {
            ViewData.Model = _shoppingCartLogic.RemoveBookFromCart(HttpContext.Session, id);
            return RedirectToAction("Index");
        }

        

        [HttpPost]
        //[ValidateInput(true)]
        public ActionResult Edit(EditArguments editArgs)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            _shoppingCartLogic.EditBookInCart(HttpContext.Session, editArgs);

            return RedirectToAction("Index");
        }

        


        
    }
}