
Feature: Searching for books
	As a potential customer
	I want to search for books by a simple phrase
	So that I can easily allocate books by something I remember from them.

Background:
	Given the following books
		|Author			|Title								|
		|Martin Fowler	|Analysis Patterns					|
		|Eric Evans		|Domain Driven Design				|
		|Ted Pattison	|Inside Windows SharePoint Services	|
		|Gojko Adzic	|Bridging the Communication Gap		|

@WI:1
@WI:3
Scenario: Title should be matched
	When I search for books by the phrase 'Domain'
	Then the list of found books should contain only: 'Domain Driven Design'


@WI:1
@WI:4
Scenario: Author should be matched
	When I search for books by the phrase 'Fowler'
	Then the list of found books should contain only: 'Analysis Patterns'

@WI:1
@WI:5
Scenario: Space should be treated as multiple OR search
	When I search for books by the phrase 'Windows Communication'
	Then the list of found books should contain only: 'Bridging the Communication Gap', 'Inside Windows SharePoint Services'

@WI:2
@WI:6
Scenario: Search result should be ordered by book title
	When I search for books by the phrase 'id'
	Then the list of found books should be:
		| Title                              |
		| Bridging the Communication Gap     |
		| Inside Windows SharePoint Services |

@WI:1
@WI:5
@alternative_syntax
Scenario Outline: Simple search (scenario outline syntax)
	When I search for books by the phrase '<search phrase>'
	Then the list of found books should contain only: <books>

	Examples:
		|search phrase		|books									|
		|Domain			|'Domain Driven Design'							|
		|Windows Communication	|'Bridging the Communication Gap', 'Inside Windows SharePoint Services'	|
