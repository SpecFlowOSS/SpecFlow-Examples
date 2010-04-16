Feature: US03 - Shopping cart
	As a potential customer
	I want to place books into my shopping basket 
	So that I can order several books at once.

Background:
	Given the following books
		|Id		|Author			|Title								|Price	|
		|Book1	|Martin Fowler	|Analysis Patterns					|50,20	|
		|Book2	|Eric Evans		|Domain Driven Design				|46,34	|
		|Book3	|Ted Pattison	|Inside Windows SharePoint Services	|31,49	|
		|Book4	|Gojko Adzic	|Bridging the Communication Gap		|24,75	|

Scenario: Books should be placed into basket
	Given I have a basket with: Book1
	When I place Book2 into the basket
	Then my shopping cart should contain 2 items
	And my basket should contain exactly 1 Book1
	And my basket should contain exactly 1 Book2

Scenario: Basket should initially be empty
	When I enter the shop
	Then my shopping cart should contain 0 items

Scenario: Removing a line item from the shopping cart
	Given I have a basket with: Book1
	When I delete Book1 from the basket
	Then my shopping cart should contain 0 item

Scenario: Buying one more increases quantity
	Given I have a basket with: Book1
	When I place Book1 into the basket
	Then my shopping cart should contain 1 items
	And my basket should contain exactly 2 Book1

Scenario: Increasing the quantity of a book
	Given I have a basket with: Book1
	When change the quantity of Book1 to 3
	Then my shopping cart should contain 1 items
	And my basket should contain exactly 3 Book1
