Feature: US01 - Book Search
	As a potential customer
	I want to search for books by a simple string
	So that I can easily allocate books by something I remember from them.

Background:
	Given the following books
		|Author			|Title								|Price	|
		|Martin Fowler	|Analysis Patterns					|50.20	|
		|Eric Evans		|Domain Driven Design				|46.34	|
		|Ted Pattison	|Inside Windows SharePoint Services	|31.49	|
		|Gojko Adzic	|Bridging the Communication Gap		|24.75	|

Scenario: Title should be matched
	When I perform a simple search on 'Domain' (manual)
	Then the book list should exactly contain book 'Domain Driven Design' (manual)
