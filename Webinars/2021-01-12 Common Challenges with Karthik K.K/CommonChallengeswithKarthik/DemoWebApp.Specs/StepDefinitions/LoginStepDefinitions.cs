using DemoWebApp.Specs.Support;
using FluentAssertions.Execution;
using System.Text.RegularExpressions;

namespace DemoWebApp.Specs.StepDefinitions;

[Binding]
public class LoginStepDefinitions
{
    [Given(@"I have an invalid username")]
    public void GivenIHaveAnInvalidUsername()
    {
    }

    [When(@"I login")]
    public void WhenILogin()
    {
    }

    [Then(@"I am not logged in")]
    public void ThenIAmNotLoggedIn()
    {
    }

    [Given(@"I have a valid username")]
    public void GivenIHaveAValidUsername()
    {
    }

    [Then(@"I am logged in")]
    public void ThenIAmLoggedIn()
    {
    }

    [Given(@"Username validation")]
    [Given(@"Password validation")]
    public void Validation(IEnumerable<DomainTerm> domainTerms)
    {
        var regex = new Regex("^[a-zA-Z]+[0-9]+$");

        using (new AssertionScope())
        {
            foreach (var domainTerm in domainTerms)
            {
                regex.IsMatch(domainTerm.Value!).Should().Be(domainTerm.Valid, $"{domainTerm.Value!} {domainTerm.Notes}");
            }
        }
    }
}