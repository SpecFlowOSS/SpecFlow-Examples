Feature: Pending, Inconclusive and Ignored tests

Scenario Outline: Should be able to execute scenario with Pending, Inconclusive or Ignored outcome
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		Scenario: Simple Scenario
			When I do something
		"""
	And the following bindings
		"""
		[When("I do something")]public void Do()
		{
			SpecRunner.Test<Outcome>();
		}
		"""
	When I execute the tests
	Then the execution summary should contain
		| Total | <Outcome> |
		| 1     | 1         |

Examples: 
	| Outcome      |
	| Pending      |
	| Inconclusive |
	| Ignored      |

Scenario: Should support ignored scenarios
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		@ignore
		Scenario: Simple Scenario
			When I do something
		"""
	And all steps are bound and pass
	When I execute the tests
	Then the execution summary should contain
		| Total | Ignored |
		| 1     | 1       |

Scenario: Should support ignored features
	Given I have a feature file with a scenario as
		"""
		@ignore
		Feature: Simple Feature

		Scenario: Simple Scenario 1
			When I do something

		Scenario: Simple Scenario 2
			When I do something
		"""
	And all steps are bound and pass
	When I execute the tests
	Then the execution summary should contain
		| Total | Ignored |
		| 2     | 2       |

Scenario: Should support pending steps
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature

		Scenario: Simple Scenario
			When I do something
		"""
	When I execute the tests
	Then the execution summary should contain
		| Total | Pending |
		| 1     | 1       |
