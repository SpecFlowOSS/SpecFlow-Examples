Feature: TodoApp
	Select first two items in the ToDoApp
	Enter a new item in the ToDoApp
	Add the new item to the list

@ToDoApp
Scenario: Add items to the ToDoApp
	Given that I am on the LambdaTest Sample app <profile> and <environment>
	Then select the first item
	Then select the second item
	Then find the text box to enter the new value
	Then click the Submit button
	And  verify whether the item is added to the list
	Then close the browser instance

	Examples:
		| profile	| environment |
		| single    | chrome      |
		| parallel	| chrome      |
		| parallel	| firefox     |
		| parallel	| safari      |
		| parallel	| ie          |