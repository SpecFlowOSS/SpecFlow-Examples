@automated
@WI7
Feature: Home Screen
Home Screen is displayed when entering the shop and offers to [search for a book](<BookShop.AcceptanceTests/Features/Book Search.feature>).

Background:
	Given the following books
		| Title                              | Price |
		| Analysis Patterns                  | 50.20 |
		| Domain Driven Design               | 46.34 |
		| Inside Windows SharePoint Services | 31.49 |
		| Bridging the Communication Gap     | 24.75 |

@WI8
Scenario: Cheapest 3 books should be listed on the home screen
	When I enter the shop
	Then the home screen should show the book 'Bridging the Communication Gap'
	And the home screen should show the book 'Inside Windows SharePoint Services'
	And the home screen should show the book 'Domain Driven Design'

@alternative_syntax
@WI8
Scenario: Cheapest 3 books should be listed on the home screen (list syntax)
	When I enter the shop
	Then the home screen should show the books 'Bridging the Communication Gap', 'Inside Windows SharePoint Services', 'Domain Driven Design'

@alternative_syntax
@WI8
Scenario: Cheapest 3 books should be listed on the home screen (table syntax)
	When I enter the shop
	Then the home screen should show the following books
		| Title                              |
		| Bridging the Communication Gap     |
		| Inside Windows SharePoint Services |
		| Domain Driven Design               |