Feature: Relocate test assembly configuration file for running the test

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
				Console.WriteLine("Config:" + System.Configuration.ConfigurationManager.AppSettings["foo"]);
			}
		"""

@config
Scenario: Should be able to specify relocation in the config file
	Given there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-8"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
			<DeploymentTransformation>
				<Steps>
					<RelocateConfigurationFile target="CustomConfig.config" />
					<ConfigFileTransformation configFile="App.config">
						<Transformation><![CDATA[<?xml version="1.0" encoding="utf-8"?>
							<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
							  <appSettings>
								<add key="foo" value="bar" xdt:Locator="Match(key)" xdt:Transform="Insert"/>
							  </appSettings>
							</configuration>
						]]></Transformation>
					</ConfigFileTransformation>
				</Steps>
			</DeploymentTransformation>
		</TestProfile>
        """
	When I execute the tests through the console runner
	Then the console runner log should contain 'Config:bar'

@config
Scenario: Should be able to use custom configuration files for parallel execution
	For parallel execution, if the configuration file should be different for each thread, 
	RelocateConfigurationFile gives a better alternative to the Relocate step. See also 'Parallel test execution' feature.
	Given there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-8"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
			<DeploymentTransformation>
				<Steps>
					<RelocateConfigurationFile target="CustomConfig{TestThreadId}.config" />
					<ConfigFileTransformation configFile="App.config">
						<Transformation><![CDATA[<?xml version="1.0" encoding="utf-8"?>
							<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
							  <appSettings>
								<add key="foo" value="bar" xdt:Locator="Match(key)" xdt:Transform="Insert"/>
							  </appSettings>
							</configuration>
						]]></Transformation>
					</ConfigFileTransformation>
				</Steps>
			</DeploymentTransformation>
		</TestProfile>
        """
	When I execute the tests through the console runner
	Then the console runner log should contain 'Config:bar'


