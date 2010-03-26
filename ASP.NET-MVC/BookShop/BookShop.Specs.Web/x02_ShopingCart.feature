Feature: Shopping cart 2
	As a potential customer
	I want to place books into my shopping basket 
	So that I can order several books at once.

  Background:
	Given the following books
        |Id		|Author			|Title									|Price	|
        |Book1	|Martin Fowler	|Patterns of Enterprise Architecture	|10,05	|
        |Book2	|Eric Evans		|Domain Driven Design					|15,10	|
        |Book3	|Ted Pattison	|Inside Windows SharePoint Services		|9,75	|
        
  Scenario: Navigation: Putting a book into the shopping cart
	When I put a book into my shopping cart
    Then the resulting page should be 'ShoppingCart'

  Scenario: Putting one book into the shopping cart
	When I put a book into my shopping cart
    Then my shopping cart should contain 1 item
    And the total price should be set
    
  Scenario: Removing a line item from the shopping cart
	When I put a book into my shopping cart
    Then my shopping cart should contain 1 item
    When I remove the first line item of my shopping cart
    Then my shopping cart should contain 0 item

  Scenario: Editing a line item of the shopping cart
	When I put a book into my shopping cart
    Then my shopping cart should contain 1 item
    And the quantity should be '1'
    When I increase the quantity of the line item by '1'
    Then my shopping cart should contain 1 item
    And the quantity should be '2'

    
    