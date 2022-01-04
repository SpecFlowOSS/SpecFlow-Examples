using SpecFlow.Actions.Selenium;

namespace DemoWebApp.Specs.Pages.LandingPage
{
    internal class LandingPageElements
    {
        private readonly IBrowserInteractions _browserInteractions;

        public LandingPageElements(IBrowserInteractions browserInteractions)
        {
            _browserInteractions = browserInteractions;
        }
    }
}
