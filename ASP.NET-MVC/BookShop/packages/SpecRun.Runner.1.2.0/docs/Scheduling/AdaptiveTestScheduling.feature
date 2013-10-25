@server
Feature: Adaptive test scheduling

Background: 
	Given I have a feature file with a scenario as
		"""
		Feature: My Feature
		Scenario: Scenario 1
			When I do something
		Scenario: Scenario 2
			When I do something
		Scenario: Scenario 3
			When I do something
		"""


Scenario: Should schedule failing tests first
	Given there is a SpecRun server running
	And the following test run result is published to the server
		| Feature    | Scenario   | Result    |
		| My Feature | Scenario 1 | Succeeded |
		| My Feature | Scenario 2 | Succeeded |
		| My Feature | Scenario 3 | Failed    |
	And all steps are bound and pass
	And the test scheduler is configured to 'Adaptive'
	When I execute the tests
	Then the test are executed in the following order
		| Feature    | Scenario   | Execution Index |
		| My Feature | Scenario 3 | 0               |
		
Scenario: Should schedule frequently failing tests first
	Given there is a SpecRun server running
	And the following test run result is published to the server
		| Feature    | Scenario   | Result    |
		| My Feature | Scenario 1 | Succeeded |
		| My Feature | Scenario 2 | Succeeded |
		| My Feature | Scenario 3 | Failed    |
	And the following test run result is published to the server
		| Feature    | Scenario   | Result    |
		| My Feature | Scenario 1 | Succeeded |
		| My Feature | Scenario 2 | Failed    |
		| My Feature | Scenario 3 | Failed    |
	And all steps are bound and pass
	And the test scheduler is configured to 'Adaptive'
	When I execute the tests
	Then the test are executed in the following order
		| Feature    | Scenario   | Execution Index |
		| My Feature | Scenario 3 | 0               |
		| My Feature | Scenario 2 | 1               |
		| My Feature | Scenario 1 | 2               |
		
Scenario: Should schedule new tests first
	Given there is a SpecRun server running
	And the following test run result is published to the server 3 times
		| Feature    | Scenario   | Result    |
		| My Feature | Scenario 1 | Succeeded |
	And the following test run result is published to the server
		| Feature    | Scenario   | Result    |
		| My Feature | Scenario 1 | Succeeded |
		| My Feature | Scenario 2 | Succeeded |
	And all steps are bound and pass
	And the test scheduler is configured to 'Adaptive'
	When I execute the tests
	Then the test are executed in the following order
		| Feature    | Scenario   | Execution Index |
		| My Feature | Scenario 2 | 0               |
		
Scenario: Should schedule tests even if there are no results published for them
	Given there is a SpecRun server running
	And the following test run result is published to the server
		| Feature    | Scenario   | Result    |
		| My Feature | Scenario 1 | Succeeded |
	And all steps are bound and pass
	And the test scheduler is configured to 'Adaptive'
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 3     | 

Scenario: Should ignore test results that are not included in the current test run
	Given there is a SpecRun server running
	And the following test run result is published to the server
		| Feature    | Scenario         | Result    |
		| My Feature | No-such-scenario | Succeeded |
	And all steps are bound and pass
	And the test scheduler is configured to 'Adaptive'
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 3     | 

Scenario: Test without historical results should be scheduled ramdomly
	Given there is a SpecRun server running
	And I have a feature file with a scenario as
		"""
		Feature: Other feature in order to have enough scenario to randomize
		Scenario: Other Scenario 1
			When I do something
		Scenario: Other Scenario 2
			When I do something
		Scenario: Other Scenario 3
			When I do something
		Scenario: Other Scenario 4
			When I do something
		Scenario: Other Scenario 5
			When I do something
		"""
	And the following test run result is published to the server
		| Feature    | Scenario   | Result    |
		| My Feature | Scenario 1 | Succeeded |
	And all steps are bound and pass
	And the test scheduler is configured to 'Adaptive'
	When I execute the tests twice
	Then the execution order of the tests in the two runs should be different


