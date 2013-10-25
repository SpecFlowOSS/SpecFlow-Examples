Feature: Test Path filtering

Background: 
	Given I have a feature file with a scenario as
		"""
		Feature: Feature_1

		Scenario: Scenario_1
			When I do something

		Scenario: Scenario_2
			When I do something

		Scenario: Scenario_2 better
			When I do something
		"""
	And I have a feature file with a scenario as
		"""
			Feature: Feature_2

			Scenario: Scenario_1
				When I do something
		"""
	And all steps are bound and pass

Scenario: Should be able to filter for feature
	Given the filter is configured to 'testpath:Feature:Feature_1'
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 3     | 

Scenario: Should be able to filter for scenario
	Given the filter is configured to 'testpath:Scenario:Scenario_1'
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 2     | 

Scenario: Should be able to filter for complex path
	Given the filter is configured to 'testpath:Feature:Feature_1/Scenario:Scenario_1'
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 1     | 

Scenario: Should not include postfixed scenarios
	Given the filter is configured to 'testpath:Scenario:Scenario_2'
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 1     | 

Scenario: Should be able to filter for title contains
	Given the filter is configured to 'testpath:*Scenario_2*'
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 2     | 

Scenario: Should be able to filter for title contains of a specific type
	Given I have a feature file with a scenario as
         """
			Feature: feature title contains Scenario_2

			Scenario: Scenario_3
				When I do something
         """
	Given the filter is configured to 'testpath:Scenario:*Scenario_2*'
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 2     | 

Scenario: Should be able to filter for scenario with spaces in title
	Given I have a feature file with a scenario as
         """
		Feature: Feature_3

		Scenario: Spaces in the title
			When I do something
         """
	And the filter is configured to 'testpath:Scenario:Spaces+in+the+title'
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 1     | 

Scenario: Should be able to filter for scenario with wildcard (*) in title
	Given I have a feature file with a scenario as
         """
		Feature: Feature_3

		Scenario: Wildcard* in the title
			When I do something
		Scenario: No Wildcard in the title
			When I do something
         """
	And the filter is configured to 'testpath:Scenario:*Wildcard%2a+in+the+title'
	When I execute the tests
	Then the execution summary should contain
		| Total | 
		| 1     | 
