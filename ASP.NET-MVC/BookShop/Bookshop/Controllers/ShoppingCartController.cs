using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using BookShop.Models;

namespace BookShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        public ActionResult Index()
        {
            ViewData.Model = GetShoppingCart();
            return View("Index");
        }

        [HttpGet]
        public ActionResult AddLink(int bookId)
        {
            return Add(bookId);
        }

        [HttpPost]
        public ActionResult Add(int bookId)
        {
            BookShopEntities db = new BookShopEntities();
            var shoppingCart = GetShoppingCart();

            var existingLine = shoppingCart.Lines.SingleOrDefault(l => l.Book.Id == bookId);
            if (existingLine != null)
            {
                existingLine.Quantity++;
            }
            else
            {
                var book = db.Books.First(b => b.Id == bookId);

                OrderLine newOrderLine = new OrderLine();
                newOrderLine.Book = book;
                newOrderLine.Quantity = 1;
                shoppingCart.AddLineItem(newOrderLine);
            }

            ViewData.Model = shoppingCart;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteItem(int id)
        {
            var shoppingCart = GetShoppingCart();
            shoppingCart.RemoveLineItem(id);

            ViewData.Model = shoppingCart;
            return RedirectToAction("Index");
        }

        public class EditArguments
        {
            public int BookId { get; set; }
            [Range(0, 10)]
            public int Quantity { get; set; }
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Edit(EditArguments editArgs)
        {
            if (!ModelState.IsValid)
                return Index();

            var shoppingCart = GetShoppingCart();
            int bookId = editArgs.BookId;
            int quantity = editArgs.Quantity;

            if (quantity > 0)
            {
                var existingLine = shoppingCart.Lines.Single(l => l.Book.Id == bookId);
                existingLine.Quantity = quantity;
            }
            else
                shoppingCart.RemoveLineItem(bookId);

            return RedirectToAction("Index");
        }

        public const string CART_SESSION_KEY = "CART";
        private ShoppingCart GetShoppingCart()
        {
            var shoppingCart = (ShoppingCart)HttpContext.Session[CART_SESSION_KEY];
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart();
                HttpContext.Session[CART_SESSION_KEY] = shoppingCart;
            }

            return shoppingCart;
        }

    }
}
