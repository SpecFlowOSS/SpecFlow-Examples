# Testing an ASP.NET Core web application using .NET 6

This project contains a working example of how to test an ASP.NET Core web application using SpecFlow and .NET 6.

## Projects

### SpecFlowCalculator.sln

A simple calculator page using an ASP.NET Core web application. The calculator has basic functionality - Add, subtract, multiple, and divide. This application is the subject under test.

### SpecFlowCalculator.Specs

A test project using the NUnit framework containing 5 simple example tests in [Calculator.feature](./SpecFlowCalculator.Specs/Features/Calculator.feature) and step definitions defined in [CalculatorStepDefinitions.cs](./SpecFlowCalculator.Specs/Steps/CalculatorStepDefinitions.cs)
