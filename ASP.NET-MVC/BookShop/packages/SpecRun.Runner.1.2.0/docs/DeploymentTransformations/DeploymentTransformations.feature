Feature: Deployment transformations

Scenario: Thread-independent steps can performed globally
	Given I have a feature file with 2 passing 0 failing and 0 pending scenarios
	And the test thread count is configured to 2
	Given there is a folder '%TMP%\SpecRunTestSource_NonThreadSpecificFolder' with a sample file
	And there is a global copy folder step configured from '%TMP%\SpecRunTestSource_NonThreadSpecificFolder' to '%TMP%\SpecRunTestCopy_NonThreadSpecificFolder'
	And there is a relocate step configured to '%TMP%\SpecRunTestDeployForNonThreadSpecificStepsTest{TestThreadId}'
	When I execute the tests
	Then the execution summary should contain
         | Succeeded |
         | 2         |
	And the output should contain 'Folder '%TMP%\SpecRunTestSource_NonThreadSpecificFolder' is copied to '%TMP%\SpecRunTestCopy_NonThreadSpecificFolder'' only once
