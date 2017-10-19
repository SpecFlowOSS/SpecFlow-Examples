using TechTalk.SpecFlow;
using BookShop.AcceptanceTests.Drivers.BookDetails;

namespace BookShop.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class BookSteps
    {
        private readonly BookDetailsDriver _driver;

        public BookSteps(BookDetailsDriver driver)
        {
            this._driver = driver;
        }

        [Given(@"the following books")]
        public void GivenTheFollowingBooks(Table givenBooks)
        {
            this._driver.AddToDatabase(givenBooks);
        }

        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOfBook(string bookId)
        {
            this._driver.OpenBookDetails(bookId);
        }

        [Then(@"the book details should show")]
        public void ThenTheBookDetailsShouldShow(Table expectedBookDetails)
        {
            this._driver.ShowsBookDetails(expectedBookDetails);
        }
    }
}
