Feature: 5 Scenario Outline
The Scenario Outline keyword can be used to run the same Scenario multiple times with different combinations of values.
These are defined in the 'Examples' table and replace the < >-delimited parameters of the Scenario Outline.

By default the Scenario Outline shows the parameters. You can fill in a specific example by choosing it from the dropdown or by activating the toggle in the example table.

The following example describes a simple Scenario Outline with two examples.

Scenario Outline: Add two numbers
  Given the first number is <first>
	And the second number is <second>
	When the two numbers are added
	Then the result should be <result>

	Examples:
		| first | second | result |
		| 12    | 5      | 7      |
		| 20    | 5      | 15     |
