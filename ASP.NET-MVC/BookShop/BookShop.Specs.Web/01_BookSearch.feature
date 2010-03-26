Feature: Catalog
	As a potential customer
	I want to search for books by a simple string
	So that I can easily allocate books by something I remember from them.

	Background:
	Given the following books
        |Id		|Author			|Title									|Price	|
        |Book1	|Martin Fowler	|Patterns of Enterprise Architecture	|10,05	|
        |Book2	|Eric Evans		|Domain Driven Design					|15,10	|
        |Book3	|Ted Pattison	|Inside Windows SharePoint Services		|9,75	|
        
	Scenario: Title should be matched
		When I perform a simple search on 'Domain'
		Then the book list should exactly contain: Book2
		

	Scenario: Space should be treated as multiple OR search
		When I perform a simple search on 'Windows Enterprise'
		Then the book list should exactly contain: Book1, Book3