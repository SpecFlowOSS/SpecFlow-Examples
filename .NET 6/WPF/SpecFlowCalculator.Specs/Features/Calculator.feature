Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowCalculator.Specs/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: Subtract two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are subtracted
	Then the result should be -20

Scenario: Multiply two numbers
	Given the first number is 2
	And the second number is 70
	When the two numbers are multiplied
	Then the result should be 140

Scenario: Divide two numbers
	Given the first number is 50
	And the second number is 2
	When the two numbers are divided
	Then the result should be 25

Scenario: Divide by 0
	Given the first number is 0
	And the second number is 2
	When the two numbers are divided
	Then the result should be 0  