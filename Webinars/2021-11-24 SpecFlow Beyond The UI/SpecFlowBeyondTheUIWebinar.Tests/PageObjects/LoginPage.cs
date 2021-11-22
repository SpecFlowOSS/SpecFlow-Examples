using OpenQA.Selenium;

namespace SpecFlowBeyondTheUIWebinar.Tests.PageObjects
{
    public class LoginPage : BasePage
    {
        private IWebDriver driver;

        private By textfieldUsername = By.Name("username");
        private By textfieldPassword = By.Name("password");
        private By buttonLogin = By.XPath("//input[@value='Log In']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;

            // Change the URL to https://parabank.parasoft.com/ to run tests against public ParaBank instance
            this.driver.Navigate().GoToUrl("http://localhost:8080/parabank");
        }

        public void LoginAs(string username, string password)
        {
            SendKeys(textfieldUsername, username);
            SendKeys(textfieldPassword, password);
            this.driver.FindElement(buttonLogin).Click();
        }
    }
}
