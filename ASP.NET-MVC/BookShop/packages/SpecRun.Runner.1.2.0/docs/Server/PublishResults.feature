Feature: Publish test run results

@server
Scenario: Should publish test run results to server
	Given there is a SpecRun server running
	And I have a feature file with 3 passing 2 failing and 1 pending scenarios
	And the test result publishing is enabled
	When I execute the tests
	Then the server should have received a 'RegisterTestRunResult' command with 6 test results

@server
Scenario: Should publish undeterministic failures to server
	Given there is a SpecRun server running
	And I have a feature file with a scenario as
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
	And the test result publishing is enabled
	When I execute the tests
	Then the server should have received a 'RegisterTestRunResult' command with
		| Counter        | Count |
		| TestItems      | 1     |
		| RandomlyFailed | 1     |
