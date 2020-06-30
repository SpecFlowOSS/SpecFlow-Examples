using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Drivers
{
    public interface IHomeDriver
    {
        void Navigate();
        void ShowsBook(string expectedTitle);
        void ShowsBooks(string expectedTitles);
        void ShowsBooks(Table expectedBooks);
    }
}