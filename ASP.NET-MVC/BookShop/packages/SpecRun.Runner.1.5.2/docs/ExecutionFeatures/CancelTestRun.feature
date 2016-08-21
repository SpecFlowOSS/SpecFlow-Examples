Feature: CancelTestRun


Scenario: Test run is cancelled
	Given I have a binded feature file with '3' long running scenario each with a duration of '5' seconds

	When I execute the tests async
	But I cancel the run after '2' seconds

	Then the execution summary should contain
		| Total | Succeeded | Skipped |
		| 3     | 1         | 2       |


Scenario: Parallel Test run is cancelled
	Given I have a binded feature file with '6' long running scenario each with a duration of '5' seconds

	When I execute the tests on '3' threads async
	But I cancel the run after '2' seconds

	Then the execution summary should contain
		| Total | Succeeded | Skipped |
		| 6     | 3         | 3       |


Scenario: Parallel Test run with process seperation is cancelled
	Given I have a binded feature file with '6' long running scenario each with a duration of '5' seconds

	When I execute the tests in '3' processed async
	But I cancel the run after '2' seconds

	Then the execution summary should contain
		| Total | Succeeded | Skipped |
		| 6     | 3         | 3       |


#Scenario: Parallel Test run in console runner with process seperation is cancelled
#	Given I have a test project 'SpecRun.TestProject'
#	And I have a binded feature file with '6' long running scenario each with a duration of '10' seconds
#	And there is a specrun configuration file 'Default.srprofile' as
#		"""
#		<?xml version="1.0" encoding="utf-16"?>
#		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
#			<Execution testThreadCount="3" apartmentState="Unknown"  />
#			<Environment platform="x86" testThreadIsolation="Process"  framework="Net45" apartmentState="STA"/>
#			<TestAssemblyPaths>
#				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
#			</TestAssemblyPaths>
#		</TestProfile>
#		"""
#
#	When I execute the tests through the console runner async
#	But I cancel the console runner after '5' seconds
#
#	Then the console runner output should not contain 'Exception'
#	And the console runner output should contain 'Succeeded: 3'