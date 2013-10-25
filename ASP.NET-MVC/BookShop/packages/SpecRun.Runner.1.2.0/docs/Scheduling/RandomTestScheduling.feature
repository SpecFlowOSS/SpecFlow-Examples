Feature: Random test scheduling

Scenario: Should execute tests in random order
	Given I have a feature file with 10 passing 0 failing and 0 pending scenarios
	And the test scheduler is configured to 'Random'
	When I execute the tests twice
	Then the execution order of the tests in the two runs should be different
