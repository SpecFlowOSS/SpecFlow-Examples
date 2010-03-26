Feature: Order Submission
	In order to buy books
	As a customer
	I want to checkout my cart and commit the order.
	
  Background:
	Given the following books
        |Id		|Author			|Title									|Price	|
        |Book1	|Martin Fowler	|Patterns of Enterprise Architecture	|10,05	|
        |Book2	|Eric Evans		|Domain Driven Design					|15,10	|
        |Book3	|Ted Pattison	|Inside Windows SharePoint Services		|9,75	|
        
  Scenario: Committing a simple order
	When I put a book into my shopping cart 
    When I check out the cart
    Then an order should be created
    And the order should have 1 line item
    And the price of the order should be set
    And the order status should be 'InProgress'
