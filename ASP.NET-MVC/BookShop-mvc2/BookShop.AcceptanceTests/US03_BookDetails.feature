Feature: US03 - Book details
	As a potential customer
	I want to see the details of a book
	So that I can better decide to buy it.

  Background:
	Given the following books
        |Id		|Author			|Title									|Price	|
        |Book1	|Martin Fowler	|Patterns of Enterprise Architecture	|10,05	|
        |Book2	|Eric Evans		|Domain Driven Design					|15,10	|
        |Book3	|Ted Pattison	|Inside Windows SharePoint Services		|9,75	|
    
  Scenario: The author, the title and the price of a book can be seen
	When I open the details of Book1
	Then the book details shows
        |Author			|Title									|Price	|
        |Martin Fowler	|Patterns of Enterprise Architecture	|10,05	|
