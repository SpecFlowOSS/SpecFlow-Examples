namespace BookShop.AcceptanceTests.Drivers
{
    public interface IShoppingCartDriver
    {
        void SetShoppingCart(string bookIds);
        void Place(string bookId);
        void Delete(string bookId);
        void SetQuantity(string bookId, int quantity);
        void ContainsTypesOfItems(int expectedAmount);
        void ContainsTotalItems(int expectedQuantity);
        void ShowsTotalPriceOf(decimal expectedTotalPrice);
        void ContainsCopiesOf(string bookId, int expectedQuantity);
    }
}