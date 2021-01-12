Feature: 5 Backgrounds
A Background allows you to add some context to the scenarios that follow it. 
It can contain one or more Given steps, which are run before each scenario.
The following example describes a Background executed before a Scenario.

Background: 
	Given I have a cleared calculator

Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

