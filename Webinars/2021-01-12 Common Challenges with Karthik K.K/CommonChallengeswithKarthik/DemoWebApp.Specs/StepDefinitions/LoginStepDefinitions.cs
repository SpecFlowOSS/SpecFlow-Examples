using DemoWebApp.Models;
using DemoWebApp.Specs.Pages.LandingPage;
using DemoWebApp.Specs.Pages.LoginPage;
using DemoWebApp.Specs.Support;
using FluentAssertions.Execution;
using SpecFlow.Actions.Selenium;
using System.Text.RegularExpressions;

namespace DemoWebApp.Specs.StepDefinitions;

[Binding]
public class LoginStepDefinitions
{
    private readonly ILoginPage _loginPage;
    private readonly ILandingPage _landingPage;
    private readonly IBrowserInteractions _browserInteractions;
    public UserCredentials? _userCredentials;

    public LoginStepDefinitions(ILoginPage loginPage, ILandingPage landingPage, IBrowserInteractions browserInteractions)
    {
        _loginPage = loginPage;
        _landingPage = landingPage;
        _browserInteractions = browserInteractions;
    }

    [Given(@"I have a valid username")]
    [Given(@"I have an invalid username")]
    public void GivenIHaveAUsername(UserCredentials userCredentials)
    {
        _userCredentials = userCredentials;
    }

    [When(@"I login")]
    public void WhenILogin()
    {
        _loginPage.Login(_userCredentials!.Username, _userCredentials.Password);
    }

    [Then(@"I am not logged in")]
    public void ThenIAmNotLoggedIn()
    {
        _browserInteractions.GetUrl().Should().Be(_loginPage.Url);
    }

    [Then(@"I am logged in")]
    public void ThenIAmLoggedIn()
    {
        _browserInteractions.GetUrl().Should().Be(_landingPage.Url);
    }

    [Given(@"Username validation")]
    [Given(@"Password validation")]
    public void Validation(IEnumerable<DomainTerm> domainTerms)
    {
        var regex = new Regex(UserModel.RegexPattern);

        using (new AssertionScope())
        {
            foreach (var domainTerm in domainTerms)
            {
                regex.IsMatch(domainTerm.Value!).Should().Be(domainTerm.Valid, $"{domainTerm.Value!} {domainTerm.Notes}");
            }
        }
    }
}