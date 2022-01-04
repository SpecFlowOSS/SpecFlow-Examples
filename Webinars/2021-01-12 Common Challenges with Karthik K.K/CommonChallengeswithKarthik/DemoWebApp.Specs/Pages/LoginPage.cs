using SpecFlow.Actions.Selenium;

namespace DemoWebApp.Specs.Pages
{
    public class LoginPage
    {
        private readonly IBrowserInteractions _browserInteractions;

        public LoginPage(IBrowserInteractions _browserInteractions)
        {
            this._browserInteractions = _browserInteractions;
        }

        public void GoTo()        
        {
            _browserInteractions.GoToUrl("http://localhost:5000/");
        }
    }
}