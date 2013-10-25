Feature: Execute SpecFlow hooks

Scenario Outline: Should execute SpecFlow events
	Given I have a feature file with a scenario as
         """
		Feature: Simple Feature
		Scenario: Simple Scenario
			When I do something
         """
	And an event binding for '<event>'
	And all steps are bound and pass
	When I execute the tests
	Then the binding '<event>' was executed

Examples: 
	| event               |
	| BeforeScenario      |
	| AfterScenario       |
	| BeforeFeature       |
	| AfterFeature        |
	| BeforeTestRun       |
	| AfterTestRun        |
	| BeforeStep          |
	| AfterStep           |
	| BeforeScenarioBlock |
	| AfterScenarioBlock  |
