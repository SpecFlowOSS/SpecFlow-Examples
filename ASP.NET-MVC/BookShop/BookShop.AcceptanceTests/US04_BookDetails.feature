Feature: US04 - Book details
	As a potential customer
	I want to see the details of a book
	So that I can better decide to buy it.

Background:
	Given the following books
		|Id		|Author			|Title								|Price	|
		|Book1	|Martin Fowler	|Analysis Patterns					|50,20	|
		|Book2	|Eric Evans		|Domain Driven Design				|46,34	|
		|Book3	|Ted Pattison	|Inside Windows SharePoint Services	|31,49	|
		|Book4	|Gojko Adzic	|Bridging the Communication Gap		|24,75	|

Scenario: The author, the title and the price of a book can be seen
	When I open the details of Book1
	Then the book details shows
		|Author			|Title				|Price	|
		|Martin Fowler	|Analysis Patterns	|50,20	|
