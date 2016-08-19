Feature: Relocate deployment transformation

Background: 
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
			Console.WriteLine("ExecutionFolder:" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
		}
		"""

Scenario: Should be able to relocate application for running the tests
	Given there is a relocate step configured to '%TMP%\SpecRunTestDeployA'
	When I execute the tests
	Then the output should contain 'ExecutionFolder:%TMP%\SpecRunTestDeployA'

@config
Scenario: Should be able to specify relocate transformation in the config file
	Given there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-8"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
			<DeploymentTransformation>
				<Steps>
					<Relocate targetFolder="%TMP%\SpecRunTestDeployB" />
				</Steps>
			</DeploymentTransformation>
		</TestProfile>
        """
	When I execute the tests through the console runner
	Then the console runner log should contain 'ExecutionFolder:%TMP%\SpecRunTestDeployB'
