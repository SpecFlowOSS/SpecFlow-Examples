Feature: 3 Test Results
With SpecFlow+ LivingDoc you have the possibility to see test execution results combined with your living documentation.  
You can **hide the test results** by using the **'Test Result' toggle button** on the left side below the filter bar, 
if you don't want to see the them anywhere in your documentation. 

Features, Scenarios, Examples and steps can have the following states
- Passed
- Failed 
- Others

Steps additionally split the state 'Others' in 
- Not executed
- Skipped
- A step binding is missing
- A step was marked as Pending

The following examples from our [Bookshop Example](<LivingDoc.Demo/2 Example - Bookshop Specifications/Book Details.feature>) demonstrate scenarios with the different states. 

Background:
	Given the following books
		| Title                              | Price |
		| Analysis Patterns                  | 50.20 |
		| Domain Driven Design               | 46.34 |
		| Inside Windows SharePoint Services | 31.49 |
		| Bridging the Communication Gap     | 24.75 |

Scenario: Cheapest 3 books should be listed on the home screen (passed)
	When I enter the shop
	Then the home screen should show the books 'Bridging the Communication Gap', 'Inside Windows SharePoint Services', 'Domain Driven Design'


Scenario: Cheapest 3 book should be listed on the home screen (failed)
	When I enter the shop
	Then the home screen should show the book 'Bridging the Communication Gap'
	And the home screen should show the book 'Inside Windows SharePoint Services'
	And the home screen should show the book 'Domain Driven Design'


@ignore
Scenario: Cheapest 3 book should be listed on the home screen (other)
	When I enter the shop
	Then the home screen should show the book 'Bridging the Communication Gap'
	And the home screen should show the book 'Inside Windows SharePoint Services'
	And the home screen should show the book 'Domain Driven Design'
