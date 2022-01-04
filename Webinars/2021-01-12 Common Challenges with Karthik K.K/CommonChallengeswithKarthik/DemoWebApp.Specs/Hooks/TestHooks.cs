using DemoWebApp.Specs.Pages;

namespace DemoWebApp.Specs.Hooks
{
    [Binding]
    public sealed class TestHooks
    {
        [BeforeScenario()]
        public void BeforeScenario(LoginPage loginPage)
        {
            loginPage.GoTo();
        }
    }
}