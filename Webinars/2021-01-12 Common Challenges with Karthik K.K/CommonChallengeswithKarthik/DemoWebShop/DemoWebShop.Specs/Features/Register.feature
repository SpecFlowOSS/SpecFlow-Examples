Feature: Register

A user can register

Scenario: User can register
	Given my details are valid
		| Gender | First name | Last name | Email                            | Password   | Confirm password |
		| Male   | Jerry      | Smith     | TotallyRandomEmail123@cheese.net | @JSmith123 | @JSmith123       |
	When I register
	Then I should be registered

Scenario: User already registered
	Given I am already registered
		| Gender | First name | Last name | Email             | Password   | Confirm password |
		| Male   | Jerry      | Smith     | J.Smith@Gmail.com | @JSmith123 | @JSmith123       |
	When I register
	Then I should not be registered