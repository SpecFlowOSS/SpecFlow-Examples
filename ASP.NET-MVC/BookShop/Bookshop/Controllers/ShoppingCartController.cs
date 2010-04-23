using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookshop.Models;
using BookShop.Models;

namespace Bookshop.Controllers
{
    public class ShoppingCartController : Controller
    {
        public ActionResult Index()
        {
            ViewData.Model = GetShoppingCart();
            return View("Index");
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

        [HttpDelete]
        public void DeleteItem(int id)
        {
            var shoppingCart = GetShoppingCart();
            shoppingCart.RemoveLineItem(id);

            // return void, since this is an AJAX call
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
            var existingLine = shoppingCart.Lines.Single(l => l.Book.Id == editArgs.BookId);
            existingLine.Quantity = editArgs.Quantity;

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
