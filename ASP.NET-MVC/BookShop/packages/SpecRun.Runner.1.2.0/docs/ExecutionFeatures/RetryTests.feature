Feature: Retry Tests

Background: 
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		Scenario: Simple Scenario
			When I do something
		"""

Scenario Outline: Should be able to retry falining tests
	Given all steps are bound and fail
	And the retry mode is configured to '<retry mode>' with repeat count 3
	When I execute the tests
	Then the test 'Simple Scenario' is executed 3 times

Examples: 
	| retry mode |
	| Failing    |
	| All        |

Scenario: Should not retry passing tests if retry mode is configured to 'Failing'
	Given all steps are bound and pass
	And the retry mode is configured to 'Failing' with repeat count 3
	When I execute the tests
	Then the test 'Simple Scenario' is executed 1 times

Scenario Outline: Should not retry tests if retry mode is configured to 'None'
	Given all steps are bound and <test result>
	And the retry mode is configured to 'None' with repeat count 3
	When I execute the tests
	Then the test 'Simple Scenario' is executed 1 times

Scenarios: 
	| test result |
	| pass        |
	| fail        |

Scenario: Should be able to detect undeterministic failures
	Given the following bindings
		"""
		static int counter = 0;
		[When("I do something")]public void Do()
		{
			if ((counter++ % 2) == 0) throw new Exception("simulated undeterministic error");
		}
		"""
	And the retry mode is configured to 'All' with repeat count 3
	When I execute the tests
	Then the execution summary should contain
		| Total | Randomly failed |
		| 1     | 1               |

@config
Scenario: Should be able to specify retry mode in the config file
	Given I have a test project 'SpecRun.TestProject'
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-8"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<Execution retryFor="Failing" retryCount="4" />
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
		</TestProfile>
        """
	And all steps are bound and fail
	When I execute the tests through the console runner
	Then the console runner output should contain 'test executions: 5'
