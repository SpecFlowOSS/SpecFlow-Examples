# Testing a class library using .NET 6

This project contains a working example of how to test a class library using SpecFlow and .NET 6.

## Projects

### SpecFlowCalculator

A class library containing one class, [Calculator.cs](./SpecFlowCalculator/Calculator.cs), which is the subject under test.

### SpecFlowCalculator.Specs

A test project using the NUnit framework containing 5 simple example tests in [Calculator.feature](./SpecFlowCalculator.Specs/Features/Calculator.feature) and step definitions defined in [CalculatorStepDefinitions.cs](./SpecFlowCalculator.Specs/Steps/CalculatorStepDefinitions.cs)
