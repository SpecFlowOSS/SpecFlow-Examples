using System.Linq;
using BookShop.Mvc.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BookShop.Mvc.Logic
{
    public interface IShoppingCartLogic
    {
        ShoppingCart GetShoppingCart(ISession session);
        ShoppingCart AddBookToCart(ISession session, int bookId, ShoppingCart shoppingCart);
        ShoppingCart RemoveBookFromCart(ISession session, int id);
        void EditBookInCart(ISession session, EditArguments editArgs);
    }

    public class ShoppingCartLogic : IShoppingCartLogic
    {
        private readonly IDatabaseContext _databaseContext;
        public const string CartSessionKey = "CART";

        public ShoppingCartLogic(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public ShoppingCart GetShoppingCart(ISession session)
        {
            var sc = session.GetString(CartSessionKey);
            if (!string.IsNullOrEmpty(sc))
            {
                return JsonConvert.DeserializeObject<ShoppingCart>(sc);
            }

            var cart = new ShoppingCart();
            session.SetString(CartSessionKey, JsonConvert.SerializeObject(cart));
            return cart;
        }

        public ShoppingCart AddBookToCart(ISession session, int bookId, ShoppingCart shoppingCart)
        {
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

            
            session.SetString(CartSessionKey, JsonConvert.SerializeObject(shoppingCart));

            return shoppingCart;
        }

        public ShoppingCart RemoveBookFromCart(ISession session, int id)
        {
            var shoppingCart = GetShoppingCart(session);
            shoppingCart.RemoveLineItem(id);


            session.SetString(CartSessionKey, JsonConvert.SerializeObject(shoppingCart));

            
            return shoppingCart;
        }

        public void EditBookInCart(ISession session, EditArguments editArgs)
        {
            var shoppingCart = GetShoppingCart(session);
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

            session.SetString(CartSessionKey, JsonConvert.SerializeObject(shoppingCart));
        }

       
    }
}
