Feature: ExamplesWithRoomForImprovement
As a ParaBank client
I want to be able to open a new account
So I can manage my finances more efficiently

@ignore @ui
Scenario: A newly created account shows up in the list of accounts using the GUI
	Given John is a registered ParaBank client
	And John is on the ParaBank home page
	When they login using their credentials
	And they navigate to the Open New Account page
	And they fill in the form to open a new checking account
	Then they see a success message on screen
	And they see the newly opened account on the Accounts Overview screen

@ignore @api
Scenario: A newly created account shows up in the list of accounts using the REST API
	Given John is a registered ParaBank client
	And they want to create a new checking account
	When they POST the necessary details to /accounts
	Then they receive an HTTP 201 status code
	And the newly generated account number can be found in the response
	When they GET the list of accounts from /customers/12212/accounts
	Then they can see the new account number in the list of their accounts in the response