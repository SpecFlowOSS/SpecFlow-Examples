# Testing a class library using .NET 6

This project contains a working example of how to test a class library using SpecFlow and .NET 6.

## Projects

### SpecFlowCalculator.sln

A class library containing one class, ```Calculator.cs```, which is the subject under test.

```csharp
public class Calculator
{
    public int FirstNumber { get; set; }

    public int SecondNumber { get; set; }

    public int Add()
    {
        return FirstNumber + SecondNumber;
    }

    public int Subtract()
    {
        return FirstNumber - SecondNumber;
    }

    public int Divide()
    {
        if (FirstNumber == 0 || SecondNumber == 0)
        {
            return 0;
        }
        else
        {
            return FirstNumber / SecondNumber;
        }
    }

    public int Multiply()
    {
        return FirstNumber * SecondNumber;
    }
}
```

### SpecFlowCalculator.Specs

A test project using the NUnit framework containing 5 simple example tests.

```gherkin
@Add
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@Subtract
Scenario: Subtract two numbers
	Given the first number is 50
	And the second number is 25
	When the two numbers are subtracted
	Then the result should be 25

@Divide
Scenario: Divide two numbers
	Given the first number is 100
	And the second number is 2
	When the two numbers are divided
	Then the result should be 50

@Divide
Scenario: Divide by 0 returns 0
	Given the first number is 0
	And the second number is 70
	When the two numbers are divided
	Then the result should be 0

@Multiply
Scenario: Multiply two numbers
	Given the first number is 5
	And the second number is 50
	When the two numbers are multiplied
	Then the result should be 250
```
