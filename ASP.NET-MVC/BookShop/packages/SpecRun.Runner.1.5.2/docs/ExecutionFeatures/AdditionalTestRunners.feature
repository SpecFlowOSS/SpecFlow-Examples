@otherTestRunners
Feature: AdditionalTestRunners

Background: 
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		Scenario: Simple Scenario
			Given there is something
			When I do something
			Then something should happen
		"""

Scenario: Tests run in MsTest
	Given all steps are bound and pass
	And the SpecFlow unit test provider is configured to 'SpecRun+MsTest'
	When I execute the tests with MsTest
	Then the execution summary of the 'MsTest' test runner should contain
		| Total | Succeeded |
		| 1     | 1         |

Scenario: Tests run in NUnit
	Given all steps are bound and pass
	And the SpecFlow unit test provider is configured to 'SpecRun+NUnit'
	When I execute the tests with NUnit
	Then the execution summary of the 'NUnit' test runner should contain
		| Total | Succeeded |
		| 1     | 1         |