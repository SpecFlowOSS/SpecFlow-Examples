@SharedAppDomain
Feature: In-AppDomain Parallel Execution

Background: 
	Given I have a test project 'SpecRun.TestProject'
	And it is configured for 'SharedAppDomain' as TestThreadIsolation
	And it is configured for '2' threads
	And the following bindings
			"""
			public static int startIndex = 0;

			[When(@"I do something")]
			public void WhenIDoSomething()
			{
			var currentStartIndex = System.Threading.Interlocked.Increment(ref startIndex);
			Console.WriteLine("Start index: {0}", currentStartIndex);
			System.Threading.Thread.Sleep(200);
			var afterStartIndex = startIndex;
			if (afterStartIndex == currentStartIndex)
				Console.WriteLine("Was not parallel");
			else
				Console.WriteLine("Was parallel");
			}
			"""
	And I have a feature file
		"""
		Feature: Feature 1
		Scenario Outline: Simple Scenario Outline
			When I do something

		Examples: 
		| Count |
		| 1     |
		| 2     |
		| 3     |
		| 4     |
		| 5     |
		"""
	And I have a feature file
		"""
		Feature: Feature 2
		Scenario Outline: Simple Scenario Outline
			When I do something

		Examples: 
		| Count |
		| 1     |
		| 2     |
		| 3     |
		| 4     |
		| 5     |
		"""

Scenario: Precondition: Tests run parallel
    When I execute the tests
    Then the output should contain 'Was parallel'

Scenario: Tests should be processed parallel without failure
    When I execute the tests
    Then the output should contain 'Was parallel'
	And the execution summary should contain
		| Total | Succeeded |
		| 10    | 10        |

Scenario Outline: Current context cannot be used in multi-threaded execution
	Given I have a feature file
		"""
		Feature: Feature with <context>.Current
		Scenario: Simple Scenario
	      When I use <context>.Current
		"""
	And the following bindings
         """
         [When(@"I use <context>.Current")]
		 public void WhenIUseContextCurrent()
		 {
            System.Threading.Thread.Sleep(200);
            Console.WriteLine(<context>.Current);
		 }
         """
    When I execute the tests
    Then the output should contain 'Was parallel'
	And the execution summary should contain
		| Failed |
		| 1      |

Examples: 
    | context             |
    | ScenarioContext     |
    | FeatureContext      |
    | ScenarioStepContext |