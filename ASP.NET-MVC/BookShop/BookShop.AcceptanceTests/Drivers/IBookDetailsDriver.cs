using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Drivers
{
    public interface IBookDetailsDriver
    {
        void OpenBookDetails(string bookId);
        void ShowsBookDetails(Table expectedBookDetails);
    }
}