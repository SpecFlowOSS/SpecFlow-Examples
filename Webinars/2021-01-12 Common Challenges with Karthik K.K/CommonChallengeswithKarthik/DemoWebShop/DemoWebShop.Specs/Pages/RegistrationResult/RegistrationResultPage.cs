using SpecFlow.Actions.Selenium;

namespace DemoWebShop.Specs.Pages.RegistrationResult;

internal class RegistrationResultPage : RegistrationResultPageElements, IRegistrationResultPage
{
    public RegistrationResultPage(BrowserDriver browserDriver) : base(browserDriver)
    {
    }

    public bool RegistrationIsSuccess()
    {
        return this.RegistrationSuccessLabel.Displayed;
    }
}