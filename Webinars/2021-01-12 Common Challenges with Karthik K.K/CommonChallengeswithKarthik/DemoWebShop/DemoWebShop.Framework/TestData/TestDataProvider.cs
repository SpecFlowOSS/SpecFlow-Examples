namespace DemoWebShop.Framework.TestData;

public class TestDataProvider : ITestDataProvider
{
    public string GetRandomEmailAddress()
    {
        return Faker.Internet.Email();
    }
}
