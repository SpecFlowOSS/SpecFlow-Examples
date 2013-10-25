Feature: Config file transformation for running the test

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

Scenario: Should be able to convert the test assembly config file
	Given I configure a config transformation for 'SpecRun.TestProject.dll.config' as
		"""
		<?xml version="1.0"?>
		<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
		  <appSettings>
			<add key="foo" value="bar" xdt:Locator="Match(key)" xdt:Transform="Insert"/>
		  </appSettings>
		</configuration>
		"""
	When I execute the tests
	Then the output should contain 'Config:bar'

Scenario: Should be able to convert app.config
	And I configure a config transformation for 'App.config' as
		"""
		<?xml version="1.0"?>
		<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
		  <appSettings>
			<add key="foo" value="bar" xdt:Locator="Match(key)" xdt:Transform="Insert"/>
		  </appSettings>
		</configuration>
		"""
	When I execute the tests
	Then the output should contain 'Config:bar'

@config
Scenario: Should be able to specify config transformation in the config file
	Given there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-8"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
			<DeploymentTransformation>
				<Steps>
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

Scenario: Should be able to refer to the base folder from transformation
	Given I have a test project 'SpecRun.TestProject'
	And there is a feature file with 1 scenarios displaying the app setting 'foo'
	And there is a relocate step configured to '%TMP%\SpecRunTestDeploy_BaseFolderTest'
	And I configure a config transformation for 'App.config' as
		"""
		<?xml version="1.0"?>
		<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
		  <appSettings>
			<add key="foo" value="{BaseFolder}" xdt:Locator="Match(key)" xdt:Transform="Insert"/>
		  </appSettings>
		</configuration>
		"""
	When I execute the tests
	Then the output should contain 'Config:%TMP%\SpecRunTestDeploy_BaseFolderTest'

Scenario: Should be able to refer to the original base folder from transformation
	Given I have a test project 'SpecRun.TestProject'
	And there is a feature file with 1 scenarios displaying the app setting 'foo'
	And there is a relocate step configured to '%TMP%\SpecRunTestDeploy_OriginalBaseFolderTest'
	And I configure a config transformation for 'App.config' as
		"""
		<?xml version="1.0"?>
		<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
		  <appSettings>
			<add key="foo" value="{OriginalBaseFolder}" xdt:Locator="Match(key)" xdt:Transform="Insert"/>
		  </appSettings>
		</configuration>
		"""
	When I execute the tests
	Then the output should not contain 'Config:{OriginalBaseFolder}'

