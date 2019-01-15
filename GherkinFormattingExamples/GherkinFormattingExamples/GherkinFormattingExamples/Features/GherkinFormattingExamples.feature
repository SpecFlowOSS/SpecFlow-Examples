Feature: GherkinFormattingExamples

#-------------------------------------------------------------
Scenario: Discernible Given-When-Then Blocks
	In order to quickly spot where one block ends and another one begins, 
	you can indent the steps starting with “And”

	Given I need to prepare some data for my scenario
		
		And this is more complex so I need a second step

		And this is more complex so I need a third step

	When I trigger some action 

	Then I can see the expected outcome 
		
		And this outcome also has a second step

		And this outcome also has a third step


#-------------------------------------------------------------
Scenario: Discernible Given-When-Then Blocks with Tables
	Using tables this convention might make it uneasy for the eye

	Given I need to prepare the following data for my scenario:
		| column 1  | column 2 |
		| necessary | data     |
		
		And this is more complex so I need a second step with a table:
			| column x | column y |
			| more     | data     |

		And this is more complex so I need a third step with a table:
			| column z | column c |
			| more     | data     |

	When I trigger some action 

	Then I can see the expected outcome 
		
		And this outcome also has a second step

		And this outcome also has a third step


#-------------------------------------------------------------
Scenario: Discernible Given-When-Then Blocks with Tables - Alternative
	be aware that newlines tend to elongate your scenario 

	Given I need to prepare the following data for my scenario:
		| column 1  | column 2 |
		| necessary | data     |
		
	And this is more complex so I need a second step with a table:
		| column x | column y |
		| more     | data     |

	And this is more complex so I need a third step with a table:
		| column z | column c |
		| more     | data     |


	When I trigger some action 


	Then I can see the expected outcome 
		
	And this outcome also has a second step

	And this outcome also has a third step


