using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowBeyondTheUIWebinar.Models;
using SpecFlowBeyondTheUIWebinar.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace SpecFlowBeyondTheUIWebinar.Tests.StepDefinitions
{
    [Binding, Scope(Tag = "ui")]
    public class AccountCreationUISteps
    {
        private IWebDriver driver;
        private string newAccountNumber = default!;

        private Customer customerJohn = new Customer
        {
            FirstName = "John",
            LastName = "Smith",
            UserName = "john",
            Password = "demo",
            Id = 12212
        };

        public AccountCreationUISteps() => driver = new ChromeDriver();

        [BeforeScenario]
        public void MaximizeTheBrowser()
        {
            driver.Manage().Window.Maximize();
        }

        [Given(@"user (.*) is ready to open a new account")]
        public void UserIsReadyToOpenANewAccount(string firstName)
        {
            new LoginPage(driver)
                .LoginAs(customerJohn.UserName, customerJohn.Password);

            new AccountsOverviewPage(driver)
                .SelectMenuItem("Open New Account");
        }

        [When(@"they open a new (checking|savings) account")]
        public void TheyOpenANewAccount(string accountType)
        {
            newAccountNumber = new OpenNewAccountPage(driver)
                .OpenNewAccount(accountType);
        }

        [Then(@"the new account is included in their list of accounts")]
        public void TheNewAccountIsIncludedInTheirListOfAccounts()
        {
            new OpenNewAccountPage(driver)
                .SelectMenuItem("Accounts Overview");

            Assert.That(new AccountsOverviewPage(driver).AccountIsListed(newAccountNumber), Is.True);
        }

        [AfterScenario]
        public void CloseTheBrowser()
        {
            driver.Quit();
        }
    }
}
