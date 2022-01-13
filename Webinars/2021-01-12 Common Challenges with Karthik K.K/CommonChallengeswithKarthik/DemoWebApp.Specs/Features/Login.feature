Feature: Login

A user can login

#@UITest
#Scenario: Log in with invalid username
#	Given I go to the login page
#	And I have an invalid username
#	And I submit my details
#	When I click login
#	Then I am not logged in
#
#@UITest
#Scenario: Log in with valid username
#	Given I go to the login page
#	And I have an valid username
#	And I submit my details
#	When I click login
#	Then I am not logged in

@UITest
Scenario: Log in with invalid username
	Given I have an invalid username
		| Username  | Password   |
		| 111111111 | JordanW123 |
	When I login
	Then I am not logged in

@UITest
Scenario: Log in with valid username
	Given I have a valid username
		| Username   | Password   |
		| JordanW123 | JordanW123 |
	When I login
	Then I am logged in

Scenario: Domain term 'username'
	* Username validation
		| Value      | Valid | Notes                                     |
		| 111111111  | false | username should contains letters          |
		| ddddddddd  | false | username should contain numbers           |
		| Jordan@123 | false | username should not contain special chars |
		| JordanW123 | true  |                                           |

Scenario: Domain term 'password'
	* Password validation
		| Value      | Valid | Notes                                     |
		| 111111111  | false | password should contains letters          |
		| ddddddddd  | false | password should contain numbers           |
		| Jordan@123 | false | password should not contain special chars |
		| JordanW123 | true  |                                           |