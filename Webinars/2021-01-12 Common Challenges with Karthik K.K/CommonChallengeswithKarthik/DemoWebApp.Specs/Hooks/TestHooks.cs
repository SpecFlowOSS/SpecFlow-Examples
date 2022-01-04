using DemoWebApp.Specs.Pages.LoginPage;

namespace DemoWebApp.Specs.Hooks
{
    [Binding]
    public sealed class TestHooks
    {
        [BeforeScenario("UITest")]
        public void BeforeScenario(ILoginPage loginPage)
        {
            loginPage.GoTo();
        }
    }
}