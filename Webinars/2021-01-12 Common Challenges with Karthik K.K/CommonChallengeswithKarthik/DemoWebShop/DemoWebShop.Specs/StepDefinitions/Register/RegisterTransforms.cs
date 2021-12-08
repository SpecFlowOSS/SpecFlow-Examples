using DemoWebShop.Framework.TestData;
using DemoWebShop.Specs.Models;
using TechTalk.SpecFlow.Assist;

namespace DemoWebShop.Specs.StepDefinitions.Register;

[Binding]
internal class RegisterTransforms
{
    private readonly ITestDataProvider testDataProvider;

    public RegisterTransforms(ITestDataProvider testDataProvider)
    {
        this.testDataProvider = testDataProvider;
    }

    [StepArgumentTransformation("my details are valid")]
    public RegistrationModel GetRandomEmail(Table table)
    {
        var registrationModel = table.CreateInstance<RegistrationModel>();

        registrationModel.Email = this.testDataProvider.GetRandomEmailAddress();

        return registrationModel;
    }
}