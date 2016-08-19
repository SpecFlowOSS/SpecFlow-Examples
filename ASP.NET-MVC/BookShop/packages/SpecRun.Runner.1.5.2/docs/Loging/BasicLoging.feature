@Loging
Feature: BasicLoging


Scenario: Business Message has Thread Number in log line
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		Scenario: Simple Scenario
			Given there is something
			When I do something
			Then something should happen
		"""
	Given all steps are bound and pass
	When I execute the tests
	Then the output should contain 'Thread#0:B:Given there is something'

Scenario: Technical Message has Thread Number in log line
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		Scenario: Simple Scenario
			Given there is something
			When I do something
			Then something should happen
		"""
	Given all steps are bound and pass
	When I execute the tests
	Then the output should contain 'Thread#0:T:done: DefaultBindings.sb3()'