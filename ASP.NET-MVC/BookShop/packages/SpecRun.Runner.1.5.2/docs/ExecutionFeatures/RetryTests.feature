Feature: Retry Tests


	

Scenario Outline: Should be able to retry falining tests
	Given I have a feature file with a scenario as
			"""
			Feature: Simple Feature
			Scenario: Simple Scenario
				When I do something
			"""
	And all steps are bound and fail
	And the retry mode is configured to '<retry mode>' with repeat count 3
	When I execute the tests
	Then the test 'Simple Scenario' is executed 3 times

Examples: 
	| retry mode |
	| Failing    |
	| All        |

Scenario: Should not retry passing tests if retry mode is configured to 'Failing'
	Given I have a feature file with a scenario as
			"""
			Feature: Simple Feature
			Scenario: Simple Scenario
				When I do something
			"""
	And all steps are bound and pass
	And the retry mode is configured to 'Failing' with repeat count 3
	When I execute the tests
	Then the test 'Simple Scenario' is executed 1 times

Scenario Outline: Should not retry tests if retry mode is configured to 'None'
	Given I have a feature file with a scenario as
			"""
			Feature: Simple Feature
			Scenario: Simple Scenario
				When I do something
			"""
	And all steps are bound and <test result>
	And the retry mode is configured to 'None' with repeat count 3
	When I execute the tests
	Then the test 'Simple Scenario' is executed 1 times

Scenarios: 
	| test result |
	| pass        |
	| fail        |

Scenario: Should be able to detect undeterministic failures
	Given I have a feature file with a scenario as
			"""
			Feature: Simple Feature
			Scenario: Simple Scenario
				When I do something
			"""
	And the following bindings
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
	Given I have a feature file with a scenario as
			"""
			Feature: Simple Feature
			Scenario: Simple Scenario
				When I do something
			"""
	And I have a test project 'SpecRun.TestProject'
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

@retryBug
Scenario: Retry happens also, when all other tests are finished - console testrunner
	Given I have a test project 'SpecRun.TestProject'
	And I have a feature file with a scenario as
		"""
		Feature: Retry Feature
		
		Scenario: Not Bound
			When bla

		Scenario: Run 1
			When I run

		Scenario: Run 2
			When I run

		Scenario: Fail 1
			When I fail

		Scenario: Fail 2
			When I fail

		"""
	And the following bindings
		"""
		[When(@"I run")]
        public void WhenIRun() { }

        [When(@"I fail")]
        public void WhenIFail()
        {
            throw new System.Exception("simulated failure");
        }
		"""
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-8"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<Execution testThreadCount="3" retryCount="2" testSchedulingMode="Sequential" />
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
		</TestProfile>
        """
	When I execute the tests through the console runner
	Then the console runner output should contain 'Total: 5 (test executions: 9)'

@retryBug
Scenario: Retry happens also, when all other tests are finished
	Given I have a test project 'SpecRun.TestProject'
	And I have a feature file with a scenario as
		"""
		Feature: Retry Feature

		Scenario: Not Bound
			When bla

		Scenario: 1
			When I run

		Scenario: 2
			When I run

		Scenario: 3
			When I fail

		Scenario: 4
			When I fail
		"""
	And the following bindings
		"""
		[When(@"I run")]
        public void WhenIRun()
		{ 
			//System.Threading.Thread.Sleep(500);
		}

        [When(@"I fail")]
        public void WhenIFail()
        {
            throw new System.Exception("simulated failure");
        }
		"""
	And the test thread count is configured to 3
	And the test scheduler is configured to 'Sequential'
	And the retry mode is configured to 'Failing' with repeat count 3
	When I execute the tests
	Then the execution summary should contain
		| Failed | TotalMessage           |
		| 2      | 5 (test executions: 9) |
		