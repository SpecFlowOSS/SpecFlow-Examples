Feature: Reports (strucutre by execution order)

Background: 
	Given I have a test project 'SpecRun.TestProject'
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-16"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<Settings name="Test SpecRun Config" projectName="SpecRun Test Project" />
			<Execution stopAfterFailures="0" retryFor="None" />
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
		</TestProfile>
		"""
	And the report file is configured to 'TestRunReport.html'

Scenario: Configuration information should be included in the report
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		Scenario: Simple Scenario
			When I do something
		"""
	And all steps are bound and pass
	When I execute the tests through the console runner
	Then there should be a report 'TestRunReport.html' generated
	And the report should contain 'Test SpecRun Config'
	And the report should contain 'SpecRun Test Project'
	And the report should contain 'SpecRun.TestProject.dll'

Scenario: Success rate should be included in the report
	Given I have a feature file with 3 passing 1 failing and 0 pending scenarios
	When I execute the tests through the console runner
	Then there should be a report 'TestRunReport.html' generated
	And the report should contain '75%'

@report_test
Scenario: Should handle many tests
	Given I have a feature file with 75 passing 20 failing and 5 pending scenarios
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-8"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<Execution retryFor="Failing" retryCount="3" stopAfterFailures="0" />
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
		</TestProfile>
        """
	When I execute the tests through the console runner
	Then there should be a report 'TestRunReport.html' generated
	And the report should contain '75%'

Scenario: Console output of the test should be displayed in the report
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
			Console.WriteLine("Sample text on console out");
		}
		"""
	When I execute the tests through the console runner
	Then there should be a report 'TestRunReport.html' generated
	And the report should contain 'Sample text on console out'

Scenario: Console error of the test should be displayed in the report with a prefix
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
			Console.Error.WriteLine("Sample text on console error");
		}
		"""
	When I execute the tests through the console runner
	Then there should be a report 'TestRunReport.html' generated
	And the report should contain '[ERR]Sample text on console error'

Scenario: Scenario steps should be displayed in the report
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		Scenario: Simple Scenario
			When I do something
		"""
	And all steps are bound and pass
	When I execute the tests through the console runner
	Then there should be a report 'TestRunReport.html' generated
	And the report should contain 'When I do something'

Scenario: Scenario tags should be displayed in the report
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		@tag1 @tag2
		Scenario: Simple Scenario
			When I do something
		"""
	And all steps are bound and pass
	When I execute the tests through the console runner
	Then there should be a report 'TestRunReport.html' generated
	And the report should contain 'tags: tag1, tag2'

Scenario: Should be able to use custom render template
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		Scenario: Simple Scenario
			When I do something
		"""
	And all steps are bound and pass
	And there is a custom report template file 'CustomReportTemplate.cshtml' as
		"""
		Custom report with @Model.Summary.Total test(s)
		"""
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-16"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<Settings reportTemplate="CustomReportTemplate.cshtml" />
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
		</TestProfile>
		"""
	When I execute the tests through the console runner
	Then there should be a report 'TestRunReport.html' generated
	And the report should contain 'Custom report with 1 test(s)'
	