using DemoWebApp.Specs.Configuration;
using SpecFlow.Actions.Selenium;

namespace DemoWebApp.Specs.Pages.LandingPage
{
    internal class LandingPage : LandingPageElements, ILandingPage
    {
        private readonly IBrowserInteractions _browserInteractions;

        public LandingPage(IBrowserInteractions browserInteractions) : base(browserInteractions)
        {
            _browserInteractions = browserInteractions;
        }

        public string Url => TestConfiguration.Settings.Domain + "/Home/LandingPage";

        public void GoTo()
        {
            _browserInteractions.GoToUrl(Url);
        }
    }
}
