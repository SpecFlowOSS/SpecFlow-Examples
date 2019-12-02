@automated
Feature: Removing books from the shopping cart
	As a potential customer
	I want to collect books in a shopping cart
	So that I can order several books at once.

Background:
	Given the following books
		|Author			|Title								|Price	|
		|Martin Fowler	|Analysis Patterns					|50.20	|
		|Eric Evans		|Domain Driven Design				|46.34	|
		|Ted Pattison	|Inside Windows SharePoint Services	|31.49	|
		|Gojko Adzic	|Bridging the Communication Gap		|24.75	|

@WI18
Scenario: A type of book can be entirely removed from the shopping cart
	Given I have a shopping cart with: 'Analysis Patterns'
	When I delete 'Analysis Patterns' from the shopping cart
	Then my shopping cart should be empty
