@CCSP-1
Feature: Name Validation
				
Scenario: User must provide a name to be able to submit the entry
    Given all necessary fields except the name are filled out
    When the name 'Jane Doe' is provided
    And the submission entry is submitted
    Then the submitting of data was possible
			
Scenario: User can't submit entry without name
    Given all necessary fields except the name are filled out
    When the name stays empty
    And the submission entry is submitted
    Then the submitting of data was not possible