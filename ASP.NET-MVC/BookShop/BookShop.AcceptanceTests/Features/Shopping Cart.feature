@automated
@WI11 @WI14 @WI16 
Feature: Shopping Cart
Shopping cart allows to collect books from the [search results](<BookShop.AcceptanceTests/Features/Book Search.feature>)

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
Scenario: Overview should show total number of items and total price of shopping cart
	Given I have a shopping cart with: 'Analysis Patterns', 'Domain Driven Design'
	When I place 'Analysis Patterns' into the shopping cart
	Then my shopping cart should contain 2 types of items
	And my shopping cart should contain 3 items in total
	And my shopping cart should show a total price of 146.74

Scenario: Initially the shopping cart should be empty
	When I enter the shop
	Then my shopping cart should be empty

@WI12
Scenario: Adding books to shopping card should be possible
	Given I have a shopping cart with: 'Analysis Patterns'
	When I place 'Domain Driven Design' into the shopping cart
	Then my shopping cart should contain 2 types of items
	And my shopping cart should contain 1 copy of 'Analysis Patterns'
	And my shopping cart should contain 1 copy of 'Domain Driven Design'

@WI13
Scenario: Adding the same book to shopping cart again should increase quantity
	Given I have a shopping cart with: 'Analysis Patterns'
	When I place 'Analysis Patterns' into the shopping cart
	Then my shopping cart should contain 1 type of item
	And my shopping cart should contain 2 copies of 'Analysis Patterns'

@WI18
Scenario: Removing books from shopping cart should be possible
	Given I have a shopping cart with: 'Analysis Patterns'
	When I delete 'Analysis Patterns' from the shopping cart
	Then my shopping cart should be empty

@WI17
Scenario: Quantity of a book should be changeable
	Given I have a shopping cart with: 'Analysis Patterns'
	When I change the quantity of 'Analysis Patterns' to 3
	Then my shopping cart should contain 1 type of item
	And my shopping cart should contain 3 copies of 'Analysis Patterns'

@WI17
Scenario: Setting quantity of book to 0 should remove book from shopping cart
	Given I have a shopping cart with: 'Analysis Patterns'
	When I change the quantity of 'Analysis Patterns' to 0
	Then my shopping cart should be empty