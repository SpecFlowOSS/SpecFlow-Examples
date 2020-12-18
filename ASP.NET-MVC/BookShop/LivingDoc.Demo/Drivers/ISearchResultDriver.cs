using TechTalk.SpecFlow;

namespace LivingDoc.Demo.Drivers
{
    public interface ISearchResultDriver
    {
        void ShowsBooks(string expectedTitlesString);
        void AssertBooksInResult(Table expectedBooks);
    }
}