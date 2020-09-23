@automated
@WI16
Feature: Editing the shopping cart
	As a potential customer
	I want to collect books in a shopping cart
	So that I can order several books at once.

***Mockup:***
![Shopping Cart Mockup](./Wireframes/ShoppingCart.png)

Background:
	Given the following books
		| Title                              |
		| Analysis Patterns                  |
		| Domain Driven Design               |
		| Inside Windows SharePoint Services |
		| Bridging the Communication Gap     |

@WI17
Scenario: Quantity of a book can be changed
	Given I have a shopping cart with: 'Analysis Patterns'
	When I change the quantity of 'Analysis Patterns' to 3
	Then my shopping cart should contain 1 type of item
	And my shopping cart should contain 3 copies of 'Analysis Patterns'

@WI17
Scenario: Changing quantity of book to 0 should remove book from shopping cart
	Given I have a shopping cart with: 'Analysis Patterns'
	When I change the quantity of 'Analysis Patterns' to 0
	Then my shopping cart should be empty