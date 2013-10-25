@outproc
Feature: OutProc Test Execution

Background: 
	Given I have a test project 'SpecRun.TestProject'
	And I have a feature file with a scenario as
		"""
			Feature: Simple Feature
			Scenario: Simple Scenario
				Given there is something
				When I do something
				Then something should happen
		"""
	And all steps are bound and pass

Scenario: Should be able to run tests in a separate process
	Given there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-16"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<Environment testThreadIsolation="Process" /><!-- we set the isolation in order to ensure the separate process -->
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
		</TestProfile>
		"""
	When I execute the tests through the console runner
	Then the console runner output should contain 'Succeeded: 1'
	And the console runner log should contain 'Executing test executor at'
	And the console runner log should contain 'TechTalk.SpecRun.Framework.Executor.anycpu.clr40.exe'

Scenario: Should be able to run tests in 32-bit mode
	Given there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-16"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<Environment platform="x86" testThreadIsolation="Process" /><!-- we set the isolation in order to ensure the separate process even in x86 machines -->
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
		</TestProfile>
		"""
	When I execute the tests through the console runner
	Then the console runner output should contain 'Succeeded: 1'
	And the console runner log should contain 'TechTalk.SpecRun.Framework.Executor.x86.clr40.exe'

Scenario: Should be able to run tests in CLR 2.0
	Given the test project targets .NET v3.5
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-16"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<Environment framework="Net35" />
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
		</TestProfile>
		"""
	When I execute the tests through the console runner
	Then the console runner output should contain 'Succeeded: 1'
	And the console runner log should contain 'TechTalk.SpecRun.Framework.Executor.anycpu.clr20.exe'

Scenario: Should be able to share executor processes
	Given the test project targets .NET v3.5
	And I have a feature file with a scenario as
		"""
			Feature: Simple Feature 2
			Scenario: Simple Scenario
				Given there is something
				When I do something
				Then something should happen
		"""
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-16"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<Execution testThreadCount="2" />
			<Environment framework="Net35" />
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
		</TestProfile>
		"""
	When I execute the tests through the console runner
	Then the console runner output should contain 'Succeeded: 2'
	And the console runner log should contain 'Executing test executor at' only once

Scenario: Should be able to isolate executions in different processes
	And I have a feature file with a scenario as
		"""
			Feature: Simple Feature 2
			Scenario: Simple Scenario
				Given there is something
				When I do something
				Then something should happen
		"""
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-16"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<Execution testThreadCount="2" />
			<Environment testThreadIsolation="Process" />
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
		</TestProfile>
		"""
	When I execute the tests through the console runner
	Then the console runner output should contain 'Succeeded: 2'
	And the console runner log should contain 'Executing test executor at' twice
