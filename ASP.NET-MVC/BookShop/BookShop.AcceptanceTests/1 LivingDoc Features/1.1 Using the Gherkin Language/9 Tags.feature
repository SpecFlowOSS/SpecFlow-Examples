@TagOnFeature
Feature: 9 Tags
Tags are markers that can be assigned to features and scenarios. 
Assigning a tag to a feature is equivalent to assigning the tag to all scenarios in the feature file.
This example demonstrates a tagged Feature and a tagged Scenario. 

@TagOnScenario
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

