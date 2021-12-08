using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;

namespace DemoWebShop.Specs.Pages.RegistrationResult;

internal class RegistrationResultPageElements
{
    private readonly BrowserDriver browserDriver;

    public RegistrationResultPageElements(BrowserDriver browserDriver)
    {
        this.browserDriver = browserDriver;
    }

    internal IWebElement RegistrationSuccessLabel => this.browserDriver.Current.FindElement(By.ClassName("result"));
}