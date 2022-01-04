using BoDi;
using DemoWebApp.Specs.Pages.LandingPage;
using DemoWebApp.Specs.Pages.LoginPage;

namespace DemoWebApp.Specs.Hooks
{
    [Binding]
    public sealed class DependencyHooks
    {
        [BeforeScenario(Order = 0)]
        public void RegisterDependencies(IObjectContainer objectContainer) 
        {
            objectContainer.RegisterTypeAs<LoginPage, ILoginPage>();
            objectContainer.RegisterTypeAs<LandingPage, ILandingPage>();
        }
    }
}