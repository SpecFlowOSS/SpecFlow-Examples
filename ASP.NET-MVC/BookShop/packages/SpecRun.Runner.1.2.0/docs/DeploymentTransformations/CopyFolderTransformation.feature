@copyfoldertransformation
Feature: Copy folder deployment transformation

Background: 
	Given there is a folder '%TMP%\SpecRunTestSource' with a sample file
	And the folder '%TMP%\SpecRunTestCopy' does not exist
	And I have a test project 'SpecRun.TestProject'
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
			if (Directory.GetFiles(Environment.ExpandEnvironmentVariables(@"%TMP%\SpecRunTestCopy")).Length != 1)
				throw new Exception("folder copy not found");
		}
		"""

Scenario: Should be able to copy a folder for running the tests
	Given there is a copy folder step configured from '%TMP%\SpecRunTestSource' to '%TMP%\SpecRunTestCopy'
	When I execute the tests
	Then the execution summary should contain
		| Succeeded |
		| 1         |

@config
Scenario: Should be able to specify copy folder transformation in the config file
	Given there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-8"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
			<DeploymentTransformation>
				<Steps>
					<CopyFolder source="%TMP%\SpecRunTestSource" target="%TMP%\SpecRunTestCopy" />
				</Steps>
			</DeploymentTransformation>
		</TestProfile>
        """
	When I execute the tests through the console runner
	Then the console runner output should contain 'Succeeded: 1'
