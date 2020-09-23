@automated
Feature: Removing books from the shopping cart
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

@WI18
Scenario: A type of book can be entirely removed from the shopping cart
	Given I have a shopping cart with: 'Analysis Patterns'
	When I delete 'Analysis Patterns' from the shopping cart
	Then my shopping cart should be empty