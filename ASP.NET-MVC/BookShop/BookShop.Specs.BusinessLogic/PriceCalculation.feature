Feature: Price Calculation
	In order to submit an order
	As a customer
	I want know the total price of a shopping cart

Scenario: One book
	Given I have a book with price '10.05' and quantity '1' in my shopping cart
	Then the total price should be '10.05'
	
Scenario: One book, quantity two
	Given I have a book with price '10.05' and quantity '2' in my shopping cart
	Then the total price should be '20.10'
	
Scenario: Two books
	Given I have a book with price '10.05' and quantity '1' in my shopping cart
	And I have a book with price '5.15' and quantity '2' in my shopping cart
	Then the total price should be '20.35' 
