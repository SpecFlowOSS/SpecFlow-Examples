@automated
@WI16
Feature: Editing the shopping cart
	As a potential customer
	I want to collect books in a shopping cart
	So that I can order several books at once.

Background:
	Given the following books
		|Author			|Title								|Price	|
		|Martin Fowler	|Analysis Patterns					|50.20	|
		|Eric Evans		|Domain Driven Design				|46.34	|
		|Ted Pattison	|Inside Windows SharePoint Services	|31.49	|
		|Gojko Adzic	|Bridging the Communication Gap		|24.75	|

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
