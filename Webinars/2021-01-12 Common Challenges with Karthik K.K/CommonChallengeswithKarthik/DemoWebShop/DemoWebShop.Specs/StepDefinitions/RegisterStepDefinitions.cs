using DemoWebShop.Specs.Models;
using DemoWebShop.Specs.Pages.Register;
using DemoWebShop.Specs.Pages.RegistrationResult;
using TechTalk.SpecFlow.Assist;

namespace DemoWebShop.Specs.StepDefinitions
{
    [Binding]
    public class RegisterStepDefinitions
    {
        private RegistrationModel? registrationModel;
        private readonly IRegisterPage registerPage;
        private readonly IRegistrationResultPage registrationResultPage;

        public RegisterStepDefinitions(IRegisterPage registerPage, IRegistrationResultPage registrationResultPage)
        {
            this.registerPage = registerPage;
            this.registrationResultPage = registrationResultPage;
        }

        [Given(@"my details are valid")]
        public void GivenMyDetailsAreValid(Table table)
        {
            this.registrationModel = table.CreateInstance<RegistrationModel>();
        }

        [When(@"I register")]
        public void WhenIRegister()
        {
            this.registerPage.Register(this.registrationModel!);
            this.registerPage.SubmitRegistration();
        }

        [Then(@"I should be registered")]
        public void ThenIShouldBeRegistered()
        {
            this.registrationResultPage.RegistrationIsSuccess().Should().BeTrue();
        }

        [Then(@"I should not be registered")]
        public void ThenIShouldNotBeRegistered()
        {
            this.registerPage.RegistrationHasFailed().Should().BeTrue();
        }
    }
}