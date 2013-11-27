Feature: Console runner

Background: 
	Given I have a test project 'SpecRun.TestProject'
	And I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		Scenario: Simple Scenario
			When I do something
		"""

Scenario: Should be able to execute a simple passing scenario
	Given all steps are bound and pass
	When I execute the tests through the console runner with
         | Setting      | Value                   |
         | TestAssembly | SpecRun.TestProject.dll |
	Then the console runner output should contain 'Total: 1'

@config
Scenario: Should be able to specify the test run configuration as a test profile
	Given all steps are bound and pass
	And there is a specrun configuration file 'CustomConfig.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-16"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
		</TestProfile>
		"""
	When I execute the tests through the console runner with
		| Setting    | Value                 |
		| ConfigFile | CustomConfig.srprofile |
	Then the console runner output should contain 'Total: 1'

@config
Scenario: Should use Default.srprofile as default profile
#TODO: change something in the profile, to prove it is used
	Given all steps are bound and pass
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-16"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
		</TestProfile>
		"""
	When I execute the tests through the console runner with
		| Setting      | Value                   |
		| TestAssembly | SpecRun.TestProject.dll |
	Then the console runner output should contain 'Total: 1'

@config
Scenario: Should use assemblyfilename.srcconfig as default profile
#TODO: change something in the profile, to prove it is used
	Given all steps are bound and pass
	And there is a specrun configuration file 'SpecRun.TestProject.dll.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-16"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
		</TestProfile>
		"""
	When I execute the tests through the console runner with
		| Setting      | Value                   |
		| TestAssembly | SpecRun.TestProject.dll |
	Then the console runner output should contain 'Total: 1'

Scenario: Should be able to save tracing information to a log file
	Given all steps are bound and pass
	When I execute the tests through the console runner with
         | Setting      | Value                   |
         | TestAssembly | SpecRun.TestProject.dll |
         | LogFile      | customlog.log           |
	Then the console runner output should not contain 'When I do something'
	And there should be a file 'customlog.log' containing 'When I do something'
	And the console runner output should contain 'Total: 1'

Scenario: Should be able to specify output folder
	Given all steps are bound and pass
	When I execute the tests through the console runner with
         | Setting      | Value                   |
         | TestAssembly | SpecRun.TestProject.dll |
         | LogFile      | customlog1.log          |
         | OutputFolder | %TMP%\SpecRunOut        |
	Then there should be a file '%TMP%\SpecRunOut\customlog1.log' containing 'When I do something'
	And the console runner output should contain 'Total: 1'

@config
Scenario: Should be able to specify output folder in profile
	Given all steps are bound and pass
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-16"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<Settings outputFolder="%TMP%\SpecRunOut" />
		</TestProfile>
		"""
	When I execute the tests through the console runner with
         | Setting      | Value                   |
         | TestAssembly | SpecRun.TestProject.dll |
         | LogFile      | customlog4.log          |
	Then there should be a file '%TMP%\SpecRunOut\customlog4.log' containing 'When I do something'
	And the console runner output should contain 'Total: 1'

Scenario: Should set the current folder to the output folder
	Given the following bindings
		"""
		[When("I do something")]public void Do()
		{
			Console.WriteLine("Out: {0}", Environment.CurrentDirectory);
		}
		"""
	When I execute the tests through the console runner with
         | Setting      | Value                   |
         | TestAssembly | SpecRun.TestProject.dll |
         | LogFile      | customlog2.log          |
         | OutputFolder | %TMP%\SpecRunOut        |
	Then there should be a file '%TMP%\SpecRunOut\customlog2.log' containing 'Out: %TMP%\SpecRunOut'
	And the console runner output should contain 'Total: 1'

Scenario: Should set %SpecRun.OutputFolder% environment variable to the output folder
	Given the following bindings
		"""
		[When("I do something")]public void Do()
		{
			Console.WriteLine("Out: {0}", Environment.GetEnvironmentVariable("SpecRun.OutputFolder"));
		}
		"""
	When I execute the tests through the console runner with
         | Setting      | Value                   |
         | TestAssembly | SpecRun.TestProject.dll |
         | LogFile      | customlog3.log          |
         | OutputFolder | %TMP%\SpecRunOut        |
	Then there should be a file '%TMP%\SpecRunOut\customlog3.log' containing 'Out: %TMP%\SpecRunOut'
	And the console runner output should contain 'Total: 1'

@outproc
Scenario: Should set %SpecRun.OutputFolder% environment variable to the output folder (separate process)
	Given the following bindings
		"""
		[When("I do something")]public void Do()
		{
			Console.WriteLine("Out: {0}", Environment.GetEnvironmentVariable("SpecRun.OutputFolder"));
		}
		"""
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-16"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<Environment testThreadIsolation="Process" /><!-- we set the isolation in order to ensure the separate process -->
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
		</TestProfile>
		"""
	When I execute the tests through the console runner with
         | Setting      | Value                   |
         | TestAssembly | SpecRun.TestProject.dll |
         | LogFile      | customlog5.log          |
         | OutputFolder | %TMP%\SpecRunOut        |
	Then there should be a file '%TMP%\SpecRunOut\customlog5.log' containing 'Out: %TMP%\SpecRunOut'
	And the console runner output should contain 'Total: 1'
