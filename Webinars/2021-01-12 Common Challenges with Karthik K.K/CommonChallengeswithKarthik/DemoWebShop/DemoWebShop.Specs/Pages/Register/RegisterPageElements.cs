using DemoWebShop.Specs.Enums;
using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;

namespace DemoWebShop.Specs.Pages.Register;

internal class RegisterPageElements
{
    private readonly BrowserDriver browserDriver;

    public RegisterPageElements(BrowserDriver browserDriver)
    {
        this.browserDriver = browserDriver;
    }

    internal IWebElement GenderRadioButton(Gender gender) =>
        this.browserDriver.Current.FindElements(By.Name("Gender")).WhereElementsHaveValue(this.GetGender(gender)).Single();

    internal IWebElement FirstNameField => this.browserDriver.Current.FindElement(By.Id("FirstName"));

    internal IWebElement LastNameField => this.browserDriver.Current.FindElement(By.Id("LastName"));

    internal IWebElement EmailField => this.browserDriver.Current.FindElement(By.Id("Email"));

    internal IWebElement PasswordField => this.browserDriver.Current.FindElement(By.Id("Password"));

    internal IWebElement ConfirmPasswordField => this.browserDriver.Current.FindElement(By.Id("ConfirmPassword"));

    internal IWebElement RegisterButton => this.browserDriver.Current.FindElement(By.Id("register-button"));

    internal IWebElement EmailExistsLabel => this.browserDriver.Current.FindElement(By.XPath("//li[text()='The specified email already exists']"));

    private string GetGender(Gender gender)
    {
        return gender switch
        {
            Gender.Male => "M",
            Gender.Female => "F",
            _ => throw new NotImplementedException($"No implementation for '{gender}'"),
        };
    }
}