namespace BookShop.Controllers
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using BookShop.Models;

    public class ShoppingCartController
        : Controller
    {
        public const string CART_SESSION_KEY = "CART";

        public ActionResult Index()
        {
            this.ViewData.Model = this.GetShoppingCart();
            return this.View("Index");
        }

        [HttpGet]
        public ActionResult AddLink(int bookId) => this.Add(bookId);

        [HttpPost]
        public ActionResult Add(int bookId)
        {
            using (var db = new BookShopEntities())
            {
                var shoppingCart = this.GetShoppingCart();

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

                this.ViewData.Model = shoppingCart;
                return this.RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult DeleteItem(int id)
        {
            var shoppingCart = this.GetShoppingCart();
            shoppingCart.RemoveLineItem(id);

            this.ViewData.Model = shoppingCart;
            return this.RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Edit(EditArguments editArgs)
        {
            if (this.ModelState.IsValid)
            {
                var shoppingCart = this.GetShoppingCart();
                int bookId = editArgs.BookId;
                int quantity = editArgs.Quantity;

                if (quantity > 0)
                {
                    var existingLine = shoppingCart.Lines.Single(l => l.Book.Id == bookId);
                    existingLine.Quantity = quantity;
                }
                else
                {
                    shoppingCart.RemoveLineItem(bookId);
                }

                return this.RedirectToAction("Index");
            }
            else
            {
                return this.Index();
            }
        }

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

        public class EditArguments
        {
            public int BookId { get; set; }

            [Range(0, 10)]
            public int Quantity { get; set; }
        }
    }
}
