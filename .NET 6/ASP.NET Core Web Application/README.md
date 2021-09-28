# Testing an ASP.NET Core web application using .NET 6

This project contains a working example of how to test an ASP.NET Core web application using SpecFlow and .NET 6.

The UI interactions are performed using [SpecFlow.Actions.Selenium](https://github.com/SpecFlowOSS/SpecFlow.Actions/tree/main/Plugins/SpecFlow.Actions.Selenium).

## Projects

### SpecFlowCalculator

A simple calculator page using an ASP.NET Core web application. The calculator has basic functionality - Add, subtract, multiply, and divide. This application is the subject under test.

### SpecFlowCalculator.Specs

A test project using the NUnit framework containing 5 simple example tests in [Calculator.feature](./SpecFlowCalculator.Specs/Features/Calculator.feature) and step definitions defined in [CalculatorStepDefinitions.cs](./SpecFlowCalculator.Specs/Steps/CalculatorStepDefinitions.cs)

## Notes

### Version

This project was built using .NET6 SDK version ```6.0.100-preview.7.21379.14```

### Launching the web application from the test project

The test project creates the web host (default port https://localhost:5001/) during execution ```CreateHostBuilder``` [Kestrel](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-6.0) (default webserver for ASP.NET Core), and stops the host once the tests have completed.

```csharp
[Binding]
public sealed class EnvironmentSetupHooks
{
    private static IHost _host;

    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        _host = Program.CreateHostBuilder(null).UseContentRoot(Path.Combine(Environment.CurrentDirectory, "../../../../SpecFlowCalculator")).Build();

        _host.Start();
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        _host.StopAsync().Wait();
    }
}
```
