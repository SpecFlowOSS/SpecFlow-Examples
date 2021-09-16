# Testing an ASP.NET Core web application using .NET 6

This project contains a working example of how to test an ASP.NET Core web application using SpecFlow and .NET 6.

The UI interactions are performed using [SpecFlow.Actions.Selenium](https://github.com/SpecFlowOSS/SpecFlow.Actions/tree/main/Plugins/SpecFlow.Actions.Selenium).

## Projects

### SpecFlowCalculator.sln

A simple calculator page using an ASP.NET Core web application. The calculator has basic functionality - Add, subtract, multiply, and divide. This application is the subject under test.

### SpecFlowCalculator.Specs

A test project using the NUnit framework containing 5 simple example tests in [Calculator.feature](./SpecFlowCalculator.Specs/Features/Calculator.feature) and step definitions defined in [CalculatorStepDefinitions.cs](./SpecFlowCalculator.Specs/Steps/CalculatorStepDefinitions.cs)

## Notes

### Version

This project was built using .NET6 SDK version ```6.0.100-preview.7.21379.14```

### Launching the web application from the test project

The test project launches the web application locally (default port https://localhost:5001/) during execution using [Kestrel](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-6.0) (default webserver for ASP.NET Core), and stops the execution once the test has completed.

```csharp
[Binding]
public sealed class EnvironmentSetupHooks
{
    private static Process _process;

    [BeforeTestRun]
    public static void BeforeScenario()
    {
        _process = Process.Start(@"../../../../SpecFlowCalculator/bin/Debug/net6.0/SpecFlowCalculator.exe");
    }

    [AfterTestRun]
    public static void AfterScenario()
    {
        // Close() or Dispose() do not stop the process
        _process.Kill();
    }
}
```