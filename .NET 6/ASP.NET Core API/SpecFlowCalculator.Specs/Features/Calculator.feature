Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowCalculator.Specs/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

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