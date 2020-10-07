@automated
@WI14
Feature: Displaying the shopping cart
	As a potential customer
	I want to collect books in a shopping cart
	So that I can order several books at once.

***Mockup:***
![Shopping Cart Mockup](./Wireframes/ShoppingCart.png)

Background:
	Given the following books
		| Title                              | Price |
		| Analysis Patterns                  | 50.20 |
		| Domain Driven Design               | 46.34 |
		| Inside Windows SharePoint Services | 31.49 |
		| Bridging the Communication Gap     | 24.75 |

@WI15
Scenario: Shopping cart should show total number of items and total price
	Given I have a shopping cart with: 'Analysis Patterns', 'Domain Driven Design'
	When I place 'Analysis Patterns' into the shopping cart
	Then my shopping cart should contain 2 types of items
	And my shopping cart should contain 3 items in total
	And my shopping cart should show a total price of 146.74

Scenario: The shopping cart should be initially empty
	When I enter the shop
	Then my shopping cart should be empty