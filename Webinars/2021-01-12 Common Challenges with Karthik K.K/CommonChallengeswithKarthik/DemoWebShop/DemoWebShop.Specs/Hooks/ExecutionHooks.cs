using DemoWebShop.Specs.Pages.Register;

namespace DemoWebShop.Specs.Hooks
{
    [Binding]
    public sealed class ExecutionHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario()]
        public void BeforeScenario(IRegisterPage registerPage)
        {
            registerPage.GoTo();
        }
    }
}