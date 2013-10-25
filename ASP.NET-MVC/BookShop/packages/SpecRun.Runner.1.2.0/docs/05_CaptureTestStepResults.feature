Feature: Capture test step results

Background: 
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		Scenario: Simple Scenario
			Given there is something
			When I do something
			Then something should happen
		"""

Scenario: Should detect passing steps
	Given all steps are bound and pass
	When I execute the tests
	Then the step results should contain
		| step                         | result    |
		| Given there is something     | Succeeded |
		| When I do something          | Succeeded |
		| Then something should happen | Succeeded |

Scenario: Should detect pending steps
	When I execute the tests
	Then the step results should contain
		| step                         | result  |
		| Given there is something     | Pending |
		| When I do something          | Pending |
		| Then something should happen | Pending |

Scenario: Should detect failing given step
	Given all 'Given' steps are bound and fail
	And all 'When' steps are bound and pass
	And all 'Then' steps are bound and pass
	When I execute the tests
	Then the step results should contain
		| step                         | result  | error             |
		| Given there is something     | Failed  | simulated failure |
		| When I do something          | Skipped |                   |
		| Then something should happen | Skipped |                   |

Scenario: Should detect failing given step if there are pending steps after
	Given all 'Given' steps are bound and fail
	And all 'When' steps are bound and pass
	When I execute the tests
	Then the step results should contain
		| step                         | result  | error             |
		| Given there is something     | Failed  | simulated failure |
		| When I do something          | Skipped |                   |
		| Then something should happen | Pending |                   |
