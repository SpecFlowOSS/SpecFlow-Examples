using LivingDoc.Demo.Drivers;
using TechTalk.SpecFlow;

namespace LivingDoc.Demo.StepDefinitions
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

        [Given(@"the following book with id (.*)")]
        public void GivenTheFollowingBookWithId(int bookId)
        {
            //not used step
        }

        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOfBook(string bookTitle)
        {
            _driver.OpenBookDetails(bookTitle);
        }

        [When(@"I open the preview of '(.*)'")]
        public void WhenIOpenThePreviewOf(string bookTitle)
        {
            //not used step
        }

        [Then(@"the book details should show")]
        public void ThenTheBookDetailsShouldShow(Table expectedBookDetails)
        {
            _driver.ShowsBookDetails(expectedBookDetails);
        }

        [Then(@"the book preview should show")]
        public void ThenTheBookPreviewShouldShow(Table table)
        {
            //not used step
        }

    }
}
