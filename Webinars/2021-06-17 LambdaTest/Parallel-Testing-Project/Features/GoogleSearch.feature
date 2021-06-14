Feature: GoogleSearchLT
	Open Google
	Search for LambdaTest on the page

@GoogleSearch
Scenario: Perform Google Search for LambdaTest
	Given that I am on the Google app <profile> and <environment>
	Then click on the text box
	Then search for LambdaTest
	Then click on the first result
	Then close browser

	Examples:
		| profile	| environment |
		| single    | chrome      |
		| parallel	| chrome      |
		| parallel	| safari      |
		| parallel	| ie          |