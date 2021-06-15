@Calculator
Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](CalculatorSelenium.Specs/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120


Scenario Outline: Add two numbers permutations
	Given the first number is <First number>
	And the second number is <Second number>
	When the two numbers are added
	Then the result should be <Expected result>

Examples: Passing Examples
	| First number | Second number | Expected result |
	| 0            | 0             | 0               |
	| -1           | 10            | 9               |
	| 6            | 9             | 15              |
	| 98           | 100           | 198             |
	| 33           | 95            | 128             |
	| 13           | 2             | 15              |
	| 72           | 66            | 138             |
	| 28           | 63            | 91              |
	| 27           | 89            | 116             |
	| 93           | 3             | 96              |
	| 9            | 41            | 50              |
	| 61           | 71            | 132             |
	| 23           | 92            | 115             |
	| 22           | 4             | 26              |
	| 7            | 19            | 26              |
	| 45           | 50            | 95              |
	| 13           | 91            | 104             |
	| 30           | 50            | 80              |
	| 9            | 79            | 88              |
	| 48           | 14            | 62              |

Examples: Failing Examples
	| First number | Second number | Expected result |
	| 4            | 37            | 0               |
	| 38           | 98            | 0               |
	| 56           | 39            | 0               |
	| 92           | 52            | 0               |
	| 28           | 93            | 0               |
	| 78           | 72            | 0               |
	| 40           | 37            | 0               |
	| 96           | 86            | 0               |
	| 96           | 9             | 0               |
	| 94           | 40            | 0               |
	| 60           | 13            | 0               |
	| 21           | 95            | 0               |
	| 35           | 17            | 0               |
	| 56           | 57            | 0               |
	| 82           | 51            | 0               |
	| 96           | 75            | 0               |
	| 56           | 34            | 0               |
	| 26           | 59            | 0               |
	| 76           | 95            | 0               |
	| 14           | 46            | 0               |
	| 26           | 63            | 0               |
	| 57           | 36            | 0               |
	| 32           | 83            | 0               |