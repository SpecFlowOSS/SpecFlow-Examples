Feature: Privacy Policy
	
Scenario: User does not accept the privacy policy should be an error when submitting
	
	Given the submission entry is complete
	But the privacy policy is not accepted

	When the submission entry is submitted

	Then the submitting of data was not possible


Scenario: User agrees to privacy policy data should be submitted

	Given the submission entry is complete
	And the privacy policy is accepted

	When the submission entry is submitted

	Then the submitting of data was possible