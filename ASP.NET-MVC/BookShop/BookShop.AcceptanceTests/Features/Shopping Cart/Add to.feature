@automated
@WI11
Feature: Adding books to the shopping cart
	As a potential customer
	I want to collect books in a shopping cart
	So that I can order several books at once.

Background:
	Given the following books
		| Title                              |
		| Analysis Patterns                  |
		| Domain Driven Design               |
		| Inside Windows SharePoint Services |
		| Bridging the Communication Gap     |

@WI12
Scenario: Books can be placed into shopping cart
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