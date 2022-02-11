Feature: Auto-completion 

A user entering the text of the step receives suggestions for steps that have previously been created in the file 
The suggestions should come from the same type of step (Given,When, Then) and the And/But steps that follow 

# Comment - these steps were chosen since this is your standard example 
# For testing, a different set of steps could be chosen 

# To change to multi-file matching 
# Take one scenario (i.e. the outline one) and put it into a different file 
# Results should be the same 

Background: 

Given the existing steps 
"""
Feature: Calculator

@mytag
Scenario: Add two numbers
Given I have entered 50 into the calculator
And I have entered 70 into the calculator
When I press add
Then the result should be 120 on the screen

@mytag
Scenario Outline: Add two numbers again
Given I have entered <First> in the calculator
And I have entered <Second> into the calculator
When I press add
Then the result should be <Result> on the screen
"""

Scenario:  Characters exactly match for a step - for When 
When typing 
"""
Given I
"""
Then suggestions are presented:
| Suggestion                                   |
| I have entered 50 into the calculator        |
| I have entered 70 into the calculator        |
| I have entered <First> in the calculator     |
| I have entered <Second> into the calculator  |

Scenario: Replace with suggestion
Given these suggestions are presented 
| Suggestion                                   |
| I have entered 50 into the calculator        |
| I have entered 70 into the calculator        |
| I have entered <First> in the calculator     |
| I have entered <Second> into the calculator  |
When I select 
| I have entered 70 into the calculator        |
Then the step text after the keyword is replaced with 
""" 
I have entered 70 into the calculator  
"""


#@Question - Should it work this way 
Scenario:  The letter "a" is ignored if not the first letter # This seems to be the case 
When typing 
"""
Given I a
"""
Then suggestions are presented:
| Suggestion                                   |
| I have entered 50 into the calculator        |
| I have entered 70 into the calculator        |
| I have entered <First> in the calculator     |
| I have entered <Second> into the calculator  |


Scenario:  Characters exactly match for a step - for Then
# Maybe be repetative, but goes with the next one
When typing 
"""
Then the 
"""
Then suggestions are presented:
| Suggestion                                   |
| the result should be <Result> on the screen  |
| the result should be 120 on the screen       |

#@Question -   Should it work this way ?
Scenario:  Start character doesn't match for a step 
# Goes with previous
When typing 
"""
Then a
"""
Then suggestions are presented:
| Suggestion                                   |



#This scenario could be built up by additional examples - that would be a nice exercise 

#@Question - how many more might be needed 
Scenario: Business Rule Matching Typing to Current Steps 
* Typing Matches Step 
| Typing           | Step Text                               | Match  | Notes                                |
| the              | the result should be 120 on the screen  | Yes    |                                      |
| result           | the result should be 120 on the screen  | Yes    | matching word in the text            |
| screen           | the result should be 120 on the screen  | Yes    | matching word in the text            |
| result screen    | the result should be 120 on the screen  | Yes    | matching words in sequence           |
| screen results   | the result should be 120 on the screen  | No     | matching words not in same sequence  |


Scenario: Order of suggestions # What is your sorting rule ?   
Given suggestions are:
| Suggestion                                   |
| I have entered 50 into the calculator        |
| I have entered 70 into the calculator        |
| I have entered <First> in the calculator     |
| I have entered <Second> into the calculator  |
When displayed on screen
Then the order is
| Suggestion                                   |
| I have entered <First> in the calculator     |
| I have entered <Second> into the calculator  |
| I have entered 50 into the calculator        |
| I have entered 70 into the calculator        |

# For the multi-file   does the sorting order change?   



