using OpenQA.Selenium;

namespace SpecFlowBeyondTheUIWebinar.Tests.PageObjects
{
    public class OpenNewAccountPage : BasePage
    {
        private IWebDriver driver;

        private By dropdownAccountType = By.Id("type");
        private By dropdownFromAccountId = By.Id("fromAccountId");
        private By buttonOpenNewAccount = By.XPath("//input[@value='Open New Account']");
        private By textlabelNewAccountNumber = By.Id("newAccountId");

        public OpenNewAccountPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public string OpenNewAccount(string accountType)
        {
            Select(dropdownAccountType, accountType.ToUpper());
            Click(buttonOpenNewAccount);

            return GetElementText(textlabelNewAccountNumber);
        }
    }
}
