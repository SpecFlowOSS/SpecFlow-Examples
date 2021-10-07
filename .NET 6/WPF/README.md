# Testing a WPF application using .NET 6

This project contains a working example of how to test a WPF application using SpecFlow and .NET 6.

The tests use [Specflow.Actions.WindowsAppDriver](https://github.com/SpecFlowOSS/SpecFlow.Actions/tree/main/Plugins/SpecFlow.Actions.WindowsAppDriver) to interact with the demo app.

## Projects

### SpecFlowCalculator

A basic calculator built using a WPF application.

### SpecFlowCalculator.Specs

A test project using the NUnit framework containing 5 simple example tests in [Calculator.feature](./SpecFlowCalculator.Specs/Features/Calculator.feature) and step definitions defined in [CalculatorStepDefinitions.cs](./SpecFlowCalculator.Specs/Steps/CalculatorStepDefinitions.cs)