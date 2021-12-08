using DemoWebShop.Framework;
using DemoWebShop.Specs.Pages.Register;
using DemoWebShop.Specs.Pages.RegistrationResult;

namespace DemoWebShop.Specs.Hooks
{
    [Binding]
    public sealed class DependencyHooks
    {
        private IDependencyResolver dependencyResolver;

        public DependencyHooks(DependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }

        [BeforeScenario(Order = 0)]
        public void ResolveTypes() 
        {
            this.dependencyResolver.RegisterTypeAs<RegisterPage, IRegisterPage>();
            this.dependencyResolver.RegisterTypeAs<RegistrationResultPage, IRegistrationResultPage>();
        }
    }
}