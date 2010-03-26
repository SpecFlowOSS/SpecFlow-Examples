Feature: Catalog
	In order to find books I might buy
	As a potential customer
	I want to search for books by different criterias

  Background:
	Given the following books
        |Author			|Title	|Price	|
        |Martin Fowler	|PoEE	|10,05	|
        |Eric Evans		|DDD	|15,10	|
        
Scenario: Search for a book
	When I go to the 'Catalog' page