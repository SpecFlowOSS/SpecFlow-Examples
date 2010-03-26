using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using BookShop.Models;

namespace BookShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        public const string CART_SESSION_KEY = "CART";

        private BookShopEntities _db = Database.Instance;

        public ActionResult Index()
        {
            ViewData.Model = GetShoppingCart();
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add(int bookId)
        {
            var shoppingCart = GetShoppingCart();

//            var lineItem = shoppingCart.LineItems.Where(l => l.Book.Id == bookId).SingleOrDefault();
//            if (lineItem != null)
//            {
//                lineItem.Quantity += 1;
//            }
//            else
//            {
                Book book = _db.BookSet.Where(b => b.Id == bookId).First();

                LineItem newLineItem = new LineItem();
                newLineItem.Book = book;
                newLineItem.Quantity = 1;
                shoppingCart.AddLineItem(newLineItem);
//            }

            ViewData.Model = shoppingCart;
            return RedirectToAction("Index");
        }

        [AcceptVerbs(HttpVerbs.Delete)]
        public void DeleteItem(int bookId)
        {
            var shoppingCart = GetShoppingCart();
            shoppingCart.RemoveLineItem(bookId);

            // return void, since this is an AJAX call
        }

        public ActionResult Edit(int id)
        {
            var shoppingCart = GetShoppingCart();
            var lineItem = shoppingCart.LineItems.Where(li => li.Book.Id == id).FirstOrDefault();

            ViewData.Model = lineItem;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, int quantity)
        {
            var shoppingCart = GetShoppingCart();
            var lineItem = shoppingCart.LineItems.Where(li => li.Book.Id == id).FirstOrDefault();
            lineItem.Quantity = quantity;

            ViewData.Model = lineItem;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Submit()
        {
            var shoppingCart = GetShoppingCart();
            if (shoppingCart != null)
            {
                Order newOrder = new Order();
                newOrder.Price = shoppingCart.Price;
                newOrder.Status = "InProgress";
                foreach (var lineItem in shoppingCart.LineItems)
                {
                    newOrder.LineItems.Add(lineItem);
                    _db.AddToLineItem(lineItem);
                }
                _db.AddToOrderSet(newOrder);
                _db.SaveChanges();
                return View("Success");
            }
            
            return RedirectToAction("Index", "Home");
        }

        private ShoppingCart GetShoppingCart()
        {
            var shoppingCart = (ShoppingCart) HttpContext.Session[CART_SESSION_KEY];
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart();
                HttpContext.Session[CART_SESSION_KEY] = shoppingCart;
            }

            return shoppingCart;
        }
    }
}
