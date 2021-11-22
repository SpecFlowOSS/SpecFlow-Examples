using OpenQA.Selenium;

namespace SpecFlowBeyondTheUIWebinar.Tests.PageObjects
{
    public class AccountsOverviewPage : BasePage
    {
        private IWebDriver driver;

        public AccountsOverviewPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public bool AccountIsListed(string accountNumber)
        {
            return ElementIsVisible(By.XPath($"//table[@id='accountTable']//a[text()='{accountNumber}']"));
        }
    }
}
