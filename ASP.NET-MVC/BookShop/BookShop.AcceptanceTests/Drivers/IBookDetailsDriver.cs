using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Drivers
{
    public interface IBookDetailsDriver
    {
        void OpenBookDetails(string bookTitle);
        void ShowsBookDetails(Table expectedBookDetails);
    }
}