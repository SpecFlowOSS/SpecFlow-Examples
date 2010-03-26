using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShop.Models;

namespace BookShop.Specs.BusinessLogic
{
    public class ShoppingCartContext
    {
        private readonly ShoppingCart _shoppingCart = new ShoppingCart();

        public ShoppingCart ShoppingCart
        {
            get { return _shoppingCart; }
        }
    }
}
