Feature: Gherkin Formatting Examples

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
	In order to quickly spot where one block ends and another one begins, 
	you can indent the steps starting with “And”

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
Scenario: Reduce noise with default values
	In order to immediately spot which information is relevant for your scenario,
	fill all mandatory fields with default values in the background
	so you dont have to list them in your scenario

	Given I add a new person
		
		And this person has the birthdate '01.01.1800'

	When I try to save this person

	Then I receive the error message for 'invalid birthdate'


#-------------------------------------------------------------
Scenario: No Newlines in single line steps
	Squashed together steps with no newlines to seperate them
	makes it more difficult to discern which information belongs together

	Given I need to prepare some data for my scenario		
		And this is more complex so I need a second step
		And this is more complex so I need a third step

	When I trigger some action 

	Then I can see the expected outcome 		
		And this outcome also has a second step
		And this outcome also has a third step


#-------------------------------------------------------------
Scenario: No Newlines in steps with tables
	Squashed together steps with no newlines to seperate them
	makes it more difficult to discern which information belongs together
	especially if tables are involved

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
Scenario Outline: Newline before Examples
	Squashed together steps with no newlines to seperate them
	makes it more difficult to discern which information belongs together
	especially if tables are involved

	Given I add a new person
		
		And this person has the birthdate '<birthdate>'

	When I try to save this person

	Then I receive the error message for 'invalid birthdate'

	Examples: 
		| birthdate  |
		| 01.01.1800 |

