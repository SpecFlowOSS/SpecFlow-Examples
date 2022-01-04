using DemoWebApp.Specs.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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

            // ---- Hard wait ------
            // Useful if you cannot leverage the other waits, i.e. there is no DOM state change or randomness in async execution delays

            // Thread.Sleep(TimeSpan.FromSeconds(2));
            // ---------------------

            // ---- Implicit wait ----
            // happens by setting the driver timeouts during initialisation (in this case via SpecFlow.Actions.Selenium via specflow.actions.json config file)
            // It is by default applied to all the elements in the script.
            // We cannot wait based on a specified condition like element selectable / clickable unlike explicit.
            // -----------------------

            //---- Explicit wait ----
            // It is applicable to only a certain element which is specific to a certain condition.
            // It is usually used, when you are not aware of the time of the element visibility. It is subjected to dynamic nature.
            // Can ignore exceptions

            var waitDriver = new WebDriverWait(
                new SystemClock(),
                _browserDriver.Current,
                TimeSpan.FromSeconds(30),
                TimeSpan.FromSeconds(1));

            waitDriver.IgnoreExceptionTypes(
                typeof(ElementClickInterceptedException),
                typeof(ElementNotInteractableException),
                typeof(ElementNotSelectableException));

            waitDriver.Until(x => SubmitButton.Enabled);
            // ---------------------

            SubmitButton.Click();
        }
    }
}