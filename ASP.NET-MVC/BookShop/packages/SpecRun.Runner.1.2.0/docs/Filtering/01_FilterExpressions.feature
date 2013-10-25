Feature: Filter expressions

Background: 
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		@tag1
		Scenario: Tagged scenario
			When I do something

		Scenario: Non-Tagged scenario
			When I do something

		@tag2
		Scenario: Tagged scenario with other tag
			When I do something

		@tag2 @tag3
		Scenario: Second tagged scenario with other tag
			When I do something
		"""
	And all steps are bound and pass

Scenario: Should be able to specify a simple filter expression
	Given the filter is configured to 'tag:tag1'
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 1     | 

Scenario: Should be able to global negate an expression
	Given the filter is configured to '!tag:tag2'
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 2     | 

Scenario: Should be able to negate an expression
	Given the filter is configured to 'tag:tag2 & !tag:tag3'
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 1     | 

Scenario: Should be able to combine expressions with AND
	Given the filter is configured to 'tag:tag2 & tag:tag3'
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 1     | 

Scenario: Should be able to combine expressions with OR
	Given the filter is configured to 'tag:tag1 | tag:tag2'
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 3     | 

Scenario: Should be able to use parenthesis
	Given the filter is configured to '(tag:tag2 & tag:tag3) | tag:tag1'
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 2     | 

Scenario: Should be able to use quotes
	Given the filter is configured to 'tag:"no such tag"'
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 0     | 

Scenario: Should be able to use apostrophe
	Given the filter is configured to 'tag:'no such tag''
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 0     | 
