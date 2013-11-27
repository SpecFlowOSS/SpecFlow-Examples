Feature: Stop execution after a number of failures

Scenario: Should stop after a number of failures if configured so
	Given I have a feature file with 0 passing 3 failing and 0 pending scenarios
	And the stop after failure count is configured to 2
	When I execute the tests
	Then the execution summary should contain
         | Total | Failed | Skipped |
         | 3     | 2      | 1       |

Scenario: Should stop after 10 failures if nothing is configured
	Given I have a feature file with 0 passing 11 failing and 0 pending scenarios
	When I execute the tests
	Then the execution summary should contain
         | Total | Failed | Skipped |
         | 11    | 10     | 1       |

Scenario: Should not stop if the threshold is reached with a retry
	Given I have a feature file with 0 passing 3 failing and 0 pending scenarios
	And the stop after failure count is configured to 2
	And the retry mode is configured to 'Failing' with repeat count 2
	When I execute the tests
	Then the execution summary should contain
         | Total | Failed | Skipped |
         | 3     | 2      | 1       |

