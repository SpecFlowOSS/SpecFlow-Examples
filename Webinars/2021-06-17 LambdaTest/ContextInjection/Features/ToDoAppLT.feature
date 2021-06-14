Feature: TodoAppLT
	Select first two items in the ToDoApp
	Enter a new item in the ToDoApp
	Add the new item to the list

@ToDoApp
Scenario: Add items to the ToDoAppLT
	Given that I am on the LambdaTest Sample app
	Then select first item
	Then select second item
	Then select third item
	Then close the browser