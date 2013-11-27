Feature: Test Targets

Background: 
	Given I have a test project 'SpecRun.TestProject'

@config
Scenario: Should be able to specify targets in the config file
	Given I have a feature file with 1 passing scenario
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-8"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
		<TestAssemblyPaths>
			<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
		</TestAssemblyPaths>
		<Targets>
			<Target name="T1" />
			<Target name="T2" />
		</Targets>
		</TestProfile>
        """
	When I execute the tests through the console runner
	Then the console runner output should contain 'Succeeded: 2'

Scenario: Should be able to filter for test target in the path
	Given I have a feature file with 1 passing scenario
	And there is a test target 'T1' is defined
	And there is a test target 'T2' is defined
	And the filter is configured to 'testpath:Target:T1'
	When I execute the tests
	Then the execution summary should contain
		| Total |
		| 1     |

Scenario: Should be able to run tests in both 32-bit and 64-bit modes
	Given I have a feature file with 1 passing scenario
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-16"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<Targets>
				<Target name="32bit">
					<Environment platform="x86" testThreadIsolation="Process" /><!-- we set the isolation in order to ensure the separate process even in x86 machines -->
				</Target>
				<Target name="64bit">
					<Environment platform="x64" testThreadIsolation="Process" /><!-- we set the isolation in order to ensure the separate process even in x86 machines -->
				</Target>
			</Targets>
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
		</TestProfile>
		"""
	When I execute the tests through the console runner
	Then the console runner output should contain 'Succeeded: 2'
	And the console runner log should contain 'TechTalk.SpecRun.Framework.Executor.x86.clr40.exe'
	And the console runner log should contain 'TechTalk.SpecRun.Framework.Executor.anycpu.clr40.exe'

Scenario: Should be able to use test target name in transformations as {Target}
	Given there is a feature file with 1 scenario displaying the app setting 'foo'
	And there is a test target 'MyTarget' is defined
	And there is a relocate configuration file step configured to 'CustomConfig_TargetTest.config'
	And I configure a config transformation for 'App.config' as
		"""
		<?xml version="1.0"?>
		<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
		  <appSettings>
			<add key="foo" value="{Target}" xdt:Locator="Match(key)" xdt:Transform="Insert"/>
		  </appSettings>
		</configuration>
		"""
	When I execute the tests
	Then the output should contain 'Config:MyTarget'

@config
Scenario: Should be able to configure custom transfromation steps for a test target
	Given there is a feature file with 1 scenario displaying the app setting 'foo'
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-8"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
			<Targets>
				<Target name="MyTarget">
				  <DeploymentTransformationSteps>
					<ConfigFileTransformation configFile="App.config">
					  <Transformation>
						<![CDATA[<?xml version="1.0" encoding="utf-8"?>
							<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
							  <appSettings>
								<add key="foo" value="SpecificToMyTarget" xdt:Locator="Match(key)" xdt:Transform="Insert"/>
							  </appSettings>
							</configuration>
						]]>
					  </Transformation>
					</ConfigFileTransformation>
				  </DeploymentTransformationSteps>
				</Target>
			</Targets>
		</TestProfile>
        """
	When I execute the tests through the console runner
	Then the console runner log should contain 'Config:SpecificToMyTarget'

@config
Scenario: Should be able to filter tests in a specific profile
	Given I have a feature file with a scenario as
		"""
		Feature: Feature with a tagged scenarios
		@mytag
		Scenario: Tagged Scenario
			When I do something

		Scenario: Scenario without tags
			When I do something
		"""
	And all steps are bound and pass
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-8"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
			<Targets>
				<Target name="T1">
					<Filter>@mytag</Filter> <!-- runs only 'Tagged Scenario' -->
				</Target>
				<Target name="T2" /> <!-- runs all two tests -->
			</Targets>
		</TestProfile>
		"""
	When I execute the tests through the console runner
	Then the console runner output should contain 'Succeeded: 3'
