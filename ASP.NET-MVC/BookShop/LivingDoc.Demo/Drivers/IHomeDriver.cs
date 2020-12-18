using TechTalk.SpecFlow;

namespace LivingDoc.Demo.Drivers
{
    public interface IHomeDriver
    {
        void Navigate();
        void ShowsBook(string expectedTitle);
        void ShowsBooks(string expectedTitles);
        void ShowsBooks(Table expectedBooks);
    }
}