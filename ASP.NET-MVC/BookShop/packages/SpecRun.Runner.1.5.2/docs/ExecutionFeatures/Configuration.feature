Feature: Configuration


Background: 
	Given I have a test project 'SpecRun.TestProject'
	And I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		Scenario: Simple Scenario
			When I do something
		"""

@config
Scenario: Use Namespace http://www.specrun.com/schemas/2011/09/TestProfile
	Given all steps are bound and pass
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-16"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
		</TestProfile>
		"""
	When I execute the console runner
	Then the console runner output should contain 'Total: 1'


@config
Scenario: Use Namespace http://www.specflow.org/schemas/plus/TestProfile/1.5
	Given all steps are bound and pass
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-16"?>
		<TestProfile xmlns="http://www.specflow.org/schemas/plus/TestProfile/1.5">
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
		</TestProfile>
		"""
	When I execute the console runner
	Then the console runner output should contain 'Total: 1'


@config
Scenario: Error in profile with http://www.specrun.com/schemas/2011/09/TestProfile
	Given all steps are bound and pass
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-16"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<TestAssemblyPathssss>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPathssss>
		</TestProfile>
		"""
	When I execute the console runner
	Then the console runner output should contain 'Invalid configuration file: There is an error in XML document (6, 3). -> Unknown configuration node: TestAssemblyPathssss'

@config
Scenario: Error in profile with http://www.specflow.org/schemas/plus/TestProfile/1.5
	Given all steps are bound and pass
	And there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-16"?>
		<TestProfile xmlns="http://www.specflow.org/schemas/plus/TestProfile/1.5">
			<TestAssemblyPathssss>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPathssss>
		</TestProfile>
		"""
	When I execute the console runner
	Then the console runner output should contain 'Invalid configuration file: There is an error in XML document (6, 3). -> Unknown configuration node: TestAssemblyPathssss'