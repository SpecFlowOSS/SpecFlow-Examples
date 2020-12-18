using TechTalk.SpecFlow;

namespace LivingDoc.Demo.Drivers
{
    public interface IBookDetailsDriver
    {
        void OpenBookDetails(string bookTitle);
        void ShowsBookDetails(Table expectedBookDetails);
    }
}