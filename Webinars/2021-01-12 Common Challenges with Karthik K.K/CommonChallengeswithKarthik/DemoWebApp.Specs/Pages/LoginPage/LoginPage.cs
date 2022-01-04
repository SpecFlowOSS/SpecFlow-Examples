using DemoWebApp.Specs.Configuration;
using SpecFlow.Actions.Selenium;

namespace DemoWebApp.Specs.Pages.LoginPage
{
    public class LoginPage : LoginPageElements, ILoginPage
    {
        public string Url => TestConfiguration.Settings.Domain + "/Home/Login";

        private readonly BrowserDriver _browserDriver;
        private readonly IBrowserInteractions _browserInteractions;

        public LoginPage(BrowserDriver browserDriver, IBrowserInteractions browserInteractions) : base(browserInteractions)
        {
            _browserDriver = browserDriver;
            _browserInteractions = browserInteractions;
        }

        public void GoTo()
        {
            _browserInteractions.GoToUrl(TestConfiguration.Settings.Domain);
        }

        public void Login(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            SubmitButton.Click();
        }
    }
}