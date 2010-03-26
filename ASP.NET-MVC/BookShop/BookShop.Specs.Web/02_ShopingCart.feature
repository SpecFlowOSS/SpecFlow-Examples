Feature: Shopping cart
	As a potential customer
	I want to place books into my shopping basket 
	So that I can order several books at once.

  Background:
	Given the following books
        |Id		|Author			|Title									|Price	|
        |Book1	|Martin Fowler	|Patterns of Enterprise Architecture	|10,05	|
        |Book2	|Eric Evans		|Domain Driven Design					|15,10	|
        |Book3	|Ted Pattison	|Inside Windows SharePoint Services		|9,75	|
    
  Scenario: Books should be placed into basket
	Given I have a basket with: Book1
	When I place Book2 into the basket
	Then my shopping cart should contain 2 items
	And my basket should contain exactly 1 Book1
	And my basket should contain exactly 1 Book2

  Scenario: Basket should initially be empts
  When I enter the shop
  Then my shopping cart should contain 0 items

    
    