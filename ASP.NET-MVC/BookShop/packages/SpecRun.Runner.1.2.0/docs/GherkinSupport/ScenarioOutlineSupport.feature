Feature: Scenario outline support

Scenario: Should be able to execute a simple scenario outlines
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		Scenario Outline: Simple Scenario Outline
			When I do <what>
		Examples:
			| what        |
			| something   |
			| other thing |
		"""
	And all steps are bound and pass
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 2     | 

Scenario: Should be able to execute scenario outlines with multiple example sets
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		Scenario Outline: Simple Scenario Outline
			When I do <what>
		Examples: first set
			| what        |
			| something   |
			| other thing |
		Examples: second set
			| what         |
			| third thing  |
			| fourth thing |
		"""
	And all steps are bound and pass
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 4     | 

Scenario: Should support tagged examples
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature

		Scenario Outline: Simple Scenario Outline
			When I do <what>

		@tag1
		Examples:
			| what        |
			| something   |
			| other thing |

		Examples:
			| what        |
			| the third   |
		"""
	And all steps are bound and pass
	And the filter is configured to '@tag1'
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 2     | 

@regression
Scenario: Should support tagged examples on tagged scenario outline
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature

		@other_tag
		Scenario Outline: Simple Scenario Outline
			When I do <what>

		@tag1
		Examples:
			| what        |
			| something   |
			| other thing |

		Examples:
			| what        |
			| the third   |
		"""
	And all steps are bound and pass
	And the filter is configured to '@tag1'
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 2     | 
