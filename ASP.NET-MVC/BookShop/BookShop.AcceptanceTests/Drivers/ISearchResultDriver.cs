using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Drivers
{
    public interface ISearchResultDriver
    {
        void ShowsBooks(string expectedTitlesString);
        void AssertBooksInResult(Table expectedBooks);
    }
}