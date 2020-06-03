namespace BookShop.AcceptanceTests.Drivers
{
    public interface IShoppingCartDriver
    {
        void SetShoppingCart(string bookTitles);
        void Place(string bookTitle);
        void Delete(string bookTitle);
        void SetQuantity(string bookTitle, int quantity);
        void ContainsTypesOfItems(int expectedAmount);
        void ContainsTotalItems(int expectedQuantity);
        void ShowsTotalPriceOf(decimal expectedTotalPrice);
        void ContainsCopiesOf(string bookTitle, int expectedQuantity);
    }
}