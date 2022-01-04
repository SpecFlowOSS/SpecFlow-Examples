Feature: Login

A user can login

Scenario: Log in with invalid username
	Given I have an invalid username
	When I login
	Then I am not logged in

Scenario: Log in with valid username
	Given I have a valid username
	When I login
	Then I am logged in

Scenario: Domain term 'username'
	* Username validation
		| Value                                              | Valid | Notes                                     |
		| 111111111                                          | false | username should contains letters          |
		| ddddddddd                                          | false | username should contain numbers           |
		| Jordan@123                                         | false | username should not contain special chars |
		| JordanW123                                         | true  |                                           |

Scenario: Domain term 'password'
	* Password validation
		| Value                                              | Valid | Notes                                     |
		| 111111111                                          | false | password should contains letters          |
		| ddddddddd                                          | false | password should contain numbers           |
		| Jordan@123                                         | false | password should not contain special chars |
		| JordanW123                                         | true  |                                           |