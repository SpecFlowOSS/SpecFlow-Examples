Feature: US01 - Book Search
	As a potential customer
	I want to search for books by a simple string
	So that I can easily allocate books by something I remember from them.

	Background:
	Given the following books
        |Author			|Title									|Price	|
        |Martin Fowler	|Patterns of Enterprise Architecture	|10,05	|
        |Eric Evans		|Domain Driven Design					|15,10	|
        |Ted Pattison	|Inside Windows SharePoint Services		|9,75	|
        
	Scenario: Title should be matched
		When I perform a simple search on 'Domain'
		Then the book list should exactly contain book 'Domain Driven Design'

	Scenario: Space should be treated as multiple OR search
		When I perform a simple search on 'Windows Enterprise'
		Then the book list should exactly contain books 'Patterns of Enterprise Architecture', 'Inside Windows SharePoint Services'