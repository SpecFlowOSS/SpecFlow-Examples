using BookShop.AcceptanceTests.Drivers;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class BookSteps
    {
        private readonly IBookDetailsDriver _driver;
        private readonly DatabaseDriver _databaseDriver;

        public BookSteps(IBookDetailsDriver driver, DatabaseDriver databaseDriver)
        {
            _driver = driver;
            _databaseDriver = databaseDriver;
        }

        [Given(@"the following books")]
        public void GivenTheFollowingBooks(Table givenBooks)
        {
            _databaseDriver.AddToDatabase(givenBooks);
        }

        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOfBook(string bookTitle)
        {
            _driver.OpenBookDetails(bookTitle);
        }

        [Then(@"the book details should show")]
        public void ThenTheBookDetailsShouldShow(Table expectedBookDetails)
        {
            _driver.ShowsBookDetails(expectedBookDetails);
        }
    }
}
