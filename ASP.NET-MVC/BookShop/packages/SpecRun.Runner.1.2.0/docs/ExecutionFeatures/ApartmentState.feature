Feature: ApartmentState

Scenario: Should be able to set the ApartmentState to STA
	Given I have a test project 'SpecRun.TestProject'
	And I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		Scenario: Simple Scenario
			When I do something
		"""
	And the following bindings
		"""
		[When("I do something")]public void Do()
		{
			Console.WriteLine("ApartmentState:" + System.Threading.Thread.CurrentThread.GetApartmentState());
		}
		"""
	And the ApartmentState is configured to STA
	When I execute the tests
	Then the output should contain 'ApartmentState:STA'

@outproc
Scenario: Should be able to set the ApartmentState to STA (separate process)
	Given I have a test project 'SpecRun.TestProject'
	And I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		Scenario: Simple Scenario
			When I do something
		"""
	And the following bindings
		"""
		[When("I do something")]public void Do()
		{
			Console.WriteLine("ApartmentState:" + System.Threading.Thread.CurrentThread.GetApartmentState());
		}
		"""
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-16"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<Environment apartmentState="STA" testThreadIsolation="Process" /><!-- we set the isolation in order to ensure the separate process only because of the test -->
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
		</TestProfile>
		"""
	When I execute the tests through the console runner
	Then the console runner output should contain 'Succeeded: 1'
	And the console runner log should contain 'ApartmentState:STA'
