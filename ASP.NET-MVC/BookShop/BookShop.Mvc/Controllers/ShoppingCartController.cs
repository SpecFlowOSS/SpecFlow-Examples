using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BookShop.Mvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookShop.Mvc.Controllers
{
    public class ShoppingCartController
        : Controller
    {
        private readonly IDatabaseContext _databaseContext;
        public const string CartSessionKey = "CART";

        public ShoppingCartController(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public ActionResult Index()
        {
            var shoppingCart = GetShoppingCart();
            return View(shoppingCart);
        }

        public ActionResult Add(int bookId)
        {
            var shoppingCart = GetShoppingCart();

            var existingLine = shoppingCart.Lines.SingleOrDefault(l => l.Book.Id == bookId);
            if (existingLine != null)
            {
                existingLine.Quantity++;
            }
            else
            {
                var book = _databaseContext.Books.First(b => b.Id == bookId);

                var newOrderLine = new OrderLine
                {
                    Book = book,
                    BookId = bookId,
                    Quantity = 1
                };

                shoppingCart.AddLineItem(newOrderLine);
            }

            ViewData.Model = shoppingCart;
            HttpContext.Session.SetString(CartSessionKey, JsonConvert.SerializeObject(shoppingCart));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult DeleteItem(int id)
        {
            var shoppingCart = GetShoppingCart();
            shoppingCart.RemoveLineItem(id);

            ViewData.Model = shoppingCart;
            HttpContext.Session.SetString(CartSessionKey, JsonConvert.SerializeObject(shoppingCart));
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

            var shoppingCart = GetShoppingCart();
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

            HttpContext.Session.SetString(CartSessionKey, JsonConvert.SerializeObject(shoppingCart));

            return RedirectToAction("Index");
        }

        private ShoppingCart GetShoppingCart()
        {
            var sc = HttpContext.Session.GetString(CartSessionKey);
            if (!string.IsNullOrEmpty(sc))
            {
                return JsonConvert.DeserializeObject<ShoppingCart>(sc);
            }

            var cart = new ShoppingCart();
            HttpContext.Session.SetString(CartSessionKey, JsonConvert.SerializeObject(cart));
            return cart;
        }

        public class EditArguments
        {
            public int BookId { get; set; }

            [Range(0, int.MaxValue)]
            public int Quantity { get; set; }
        }
    }
}