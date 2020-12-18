Feature: 8 Data Tables
Data Tables can be used within single steps. 
The following example demonstrates a scenario with a simple data table. 

Scenario: Add two numbers
	Given the numbers
	| first | second |
	| 50    | 70     |
	When the two numbers are added
	Then the result should be 120