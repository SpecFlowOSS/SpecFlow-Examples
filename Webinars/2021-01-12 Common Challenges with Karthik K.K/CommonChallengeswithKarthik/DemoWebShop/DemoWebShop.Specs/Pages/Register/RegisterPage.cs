using DemoWebShop.Specs.Models;
using SpecFlow.Actions.Selenium;

namespace DemoWebShop.Specs.Pages.Register;

internal class RegisterPage : RegisterPageElements, IRegisterPage
{
    public RegisterPage(BrowserDriver browserDriver) : base(browserDriver)
    {
        this.browserDriver = browserDriver;
    }

    private const string PageUrl = "http://demowebshop.tricentis.com/register";
    private readonly BrowserDriver browserDriver;

    public void GoTo()
    {
        this.browserDriver.Current.Navigate().GoToUrl(PageUrl);
    }

    public void Register(RegistrationModel registrationModel)
    {
        this.GenderRadioButton(registrationModel.Gender).Click();
        this.FirstNameField.SendKeys(registrationModel.FirstName);
        this.LastNameField.SendKeys(registrationModel.LastName);
        this.EmailField.SendKeys(registrationModel.Email);
        this.PasswordField.SendKeys(registrationModel.Password);
        this.ConfirmPasswordField.SendKeys(registrationModel.ConfirmPassword);
    }

    public bool RegistrationHasFailed() 
    {
        return this.EmailExistsLabel.Displayed;
    }

    public void SubmitRegistration()
    {
        this.RegisterButton.Click();
    }
}