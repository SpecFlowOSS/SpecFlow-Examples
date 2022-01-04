using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;

namespace DemoWebApp.Specs.Pages.LoginPage
{
    public class LoginPageElements
    {
        private readonly IBrowserInteractions _browserInteractions;

        public LoginPageElements(IBrowserInteractions browserInteractions)
        {
            _browserInteractions = browserInteractions;
        }

        internal IWebElement UsernameField => _browserInteractions.WaitAndReturnElement(By.Id("Username"));

        internal IWebElement PasswordField => _browserInteractions.WaitAndReturnElement(By.Id("Password"));

        internal IWebElement SubmitButton => _browserInteractions.WaitAndReturnElement(By.ClassName("btn-primary"));
    }
}