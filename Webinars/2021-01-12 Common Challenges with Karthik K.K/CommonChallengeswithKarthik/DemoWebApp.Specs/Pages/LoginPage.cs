using DemoWebApp.Specs.Configuration;
using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;

namespace DemoWebApp.Specs.Pages
{
    public class LoginPage : ILoginPage
    {
        private readonly IBrowserInteractions _browserInteractions;

        public LoginPage(IBrowserInteractions _browserInteractions)
        {
            this._browserInteractions = _browserInteractions;
        }

        private IWebElement UsernameField => _browserInteractions.WaitAndReturnElement(By.Id("Username"));

        private IWebElement PasswordField => _browserInteractions.WaitAndReturnElement(By.Id("Password"));

        private IWebElement SubmitButton => _browserInteractions.WaitAndReturnElement(By.ClassName("btn btn-primary"));

        public void GoTo()        
        {
            _browserInteractions.GoToUrl(TestConfiguration.Settings.Domain);
        }

        public void Login(string username, string password) 
        {
            this.UsernameField.SendKeys(username);
            this.PasswordField.SendKeys(password);
            this.SubmitButton.Click();
        }
    }
}