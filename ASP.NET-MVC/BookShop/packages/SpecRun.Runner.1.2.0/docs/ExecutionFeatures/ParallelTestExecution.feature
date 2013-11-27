Feature: Parallel test execution

Scenario: Should provide proper result if executed parallel
	Given I have a feature file with 12 passing 6 failing and 2 pending scenarios
	And the test scheduler is configured to 'Random'
	And the test thread count is configured to 2
	When I execute the tests
	Then the execution summary should contain
		| Total | Succeeded | Failed | Pending |
		| 20    | 12        | 6      | 2       |

Scenario: Should be able to apply deployment transformations for the different threads with test folder relocation
	Given I have a test project 'SpecRun.TestProject'
	And there is a feature file with 10 scenarios displaying the app setting 'foo'
	And there is a relocate step configured to '%TMP%\SpecRunTestDeployC{TestThreadId}'
	And I configure a config transformation for 'App.config' as
		"""
		<?xml version="1.0"?>
		<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
		  <appSettings>
			<add key="foo" value="bar{TestThreadId}" xdt:Locator="Match(key)" xdt:Transform="Insert"/>
		  </appSettings>
		</configuration>
		"""
	And the test thread count is configured to 2
	When I execute the tests
	Then the output should contain 'Config:bar0'
	And the output should contain 'Config:bar1'

Scenario: Should be able to apply deployment transformations for the different threads with configuration file relocation
	Given I have a test project 'SpecRun.TestProject'
	And there is a feature file with 10 scenarios displaying the app setting 'foo'
	And there is a relocate configuration file step configured to 'CustomConfig{TestThreadId}.config'
	And I configure a config transformation for 'App.config' as
		"""
		<?xml version="1.0"?>
		<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
		  <appSettings>
			<add key="foo" value="bar{TestThreadId}" xdt:Locator="Match(key)" xdt:Transform="Insert"/>
		  </appSettings>
		</configuration>
		"""
	And the test thread count is configured to 2
	When I execute the tests
	Then the output should contain 'Config:bar0'
	And the output should contain 'Config:bar1'

@config
Scenario: Should be able to specify thread count in config file
	Given I have a feature file with 32 passing 6 failing and 2 pending scenarios
	Given there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-8"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<Execution testThreadCount="2" testSchedulingMode="Random" />
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
		</TestProfile>
        """
	When I execute the tests through the console runner
	Then the console runner output should contain 'Total: 40'

Scenario: Should be able to restrict tagged scenarios to a thread
	Given I have a test project 'SpecRun.TestProject'
	And there is a feature file with 10 scenarios displaying the app setting 'foo'
	And there is a feature file with 10 scenarios displaying the app setting 'singleThreadSetting' tagged with @single
	And there is a relocate step configured to '%TMP%\SpecRunTestDeployD{TestThreadId}'
	And I configure a config transformation for 'App.config' as
		"""
		<?xml version="1.0"?>
		<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
		  <appSettings>
			<add key="foo" value="bar{TestThreadId}" xdt:Locator="Match(key)" xdt:Transform="Insert"/>
			<add key="singleThreadSetting" value="single{TestThreadId}" xdt:Locator="Match(key)" xdt:Transform="Insert"/>
		  </appSettings>
		</configuration>
		"""
	And the test thread count is configured to 2
	And test thread 0 is configured to run tests tagged with @single
	When I execute the tests
	Then the output should contain 'Config:single0'
	And the output should not contain 'Config:single1'
	And the output should contain 'Config:bar0'
	And the output should contain 'Config:bar1'

Scenario: Restricted tests scheduled first for random scheduling
	Given I have a feature file with a scenario as
		"""
		Feature: My Feature
		Scenario: Scenario 1
			When I do something
		Scenario: Scenario 2
			When I do something
		Scenario: Scenario 3
			When I do something
		Scenario: Scenario 4
			When I do something
		@single
		Scenario: Scenario 5
			When I do something
		"""
	And all steps are bound and pass
	And the test thread count is configured to 2
	And the test scheduler is configured to 'Random'
	And test thread 0 is configured to run tests tagged with @single
	When I execute the tests
	Then the test 'Scenario 5' is executed first

