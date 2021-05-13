Feature: 4 Test Output
With SpecFlow+ LivingDoc you have the possibility to see test outputs combined with 
your living documentation.

If a scenario has test outputs attached you can hide/show the test output on each 
sceanrio by using the 'Show/Hide Test Output' button in the scenario title.

The following Test Output locations are supported:
- BeforeScenario
- BeforeStep
- InStep
- AfterStep
- AfterScenario

The following example from our [Bookshop Example](<LivingDoc.Demo/2 Example - Bookshop Specifications/Book Details.feature>) demonstrate the test outputs. 

Background:
	Given the following books
		| Title                              | Price |
		| Analysis Patterns                  | 50.20 |
		| Domain Driven Design               | 46.34 |
		| Inside Windows SharePoint Services | 31.49 |
		| Bridging the Communication Gap     | 24.75 |


Scenario: Cheapest 3 books should be listed on the home screen
	When I enter the shop
	Then the home screen should show the book 'Bridging the Communication Gap'
	And the home screen should show the book 'Inside Windows SharePoint Services'
	And the home screen should show the book 'Domain Driven Design'