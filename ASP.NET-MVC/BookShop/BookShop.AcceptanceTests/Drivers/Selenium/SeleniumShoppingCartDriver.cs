using System;

namespace BookShop.AcceptanceTests.Drivers.Selenium
{
    class SeleniumShoppingCartDriver : IShoppingCartDriver
    {
        public void SetShoppingCart(string bookIds)
        {
            throw new NotImplementedException();
        }

        public void Place(string bookId)
        {
            throw new NotImplementedException();
        }

        public void Delete(string bookId)
        {
            throw new NotImplementedException();
        }

        public void SetQuantity(string bookId, int quantity)
        {
            throw new NotImplementedException();
        }

        public void ContainsTypesOfItems(int expectedAmount)
        {
            throw new NotImplementedException();
        }

        public void ContainsTotalItems(int expectedQuantity)
        {
            throw new NotImplementedException();
        }

        public void ShowsTotalPriceOf(decimal expectedTotalPrice)
        {
            throw new NotImplementedException();
        }

        public void ContainsCopiesOf(string bookId, int expectedQuantity)
        {
            throw new NotImplementedException();
        }
    }
}