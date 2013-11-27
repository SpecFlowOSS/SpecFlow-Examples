@server
Feature: Working offline

Scenario: Should run tests when the server is not available for Adaptive scheduler
	Given I have a feature file with 3 passing 0 failing and 0 pending scenarios
	And the test scheduler is configured to 'Adaptive'
	And the SpecRun server is not running
	When I execute the tests
	Then the execution summary should contain
         | Total | Succeeded |
         | 3     | 3         |

Scenario: Should run tests when the server is not available for publishing results
	Given I have a feature file with 3 passing 0 failing and 0 pending scenarios
	And the test result publishing is enabled
	And the SpecRun server is not running
	When I execute the tests
	Then the execution summary should contain
         | Total | Succeeded |
         | 3     | 3         |

