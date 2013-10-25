Feature: Basic scenario execution

Background: 
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		Scenario: Simple Scenario
			Given there is something
			When I do something
			Then something should happen
		"""

Scenario: Should be able to execute a simple passing scenario
	Given all steps are bound and pass
	When I execute the tests
	Then the execution summary should contain
		| Total | Succeeded |
		| 1     | 1         |


Scenario: Should be able to execute a simple failing scenario
	Given all 'Given' steps are bound and fail
	When I execute the tests
	Then the execution summary should contain
		| Total | Failed |
		| 1     | 1      |

