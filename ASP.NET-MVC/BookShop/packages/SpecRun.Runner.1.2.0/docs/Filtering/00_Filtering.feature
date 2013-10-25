Feature: Filtering

Background: 
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		@mytag
		Scenario: Simple Scenario
			Given there is something
			When I do something
			Then something should happen
		"""
	And all steps are bound and pass

Scenario: Should work with empty filter
	Given the filter is configured to ''
	When I execute the tests
	Then the execution summary should contain
         | Total |
         | 1     |

Scenario: Should work with empty filter that excludes all
	Given the filter is configured to 'tag:no_such_tag'
	When I execute the tests
	Then the execution summary should contain
         | Total |
         | 0     |


@config
Scenario: Should be able to specify filter in the configuration
	Given there is a specrun configuration file 'Default.srprofile' as
		"""
		<?xml version="1.0" encoding="utf-8"?>
		<TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
			<TestAssemblyPaths>
				<TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
			</TestAssemblyPaths>
			<Filter>mytag</Filter>
		</TestProfile>
        """
	When I execute the tests through the console runner
	Then the console runner output should contain 'Total: 1'
