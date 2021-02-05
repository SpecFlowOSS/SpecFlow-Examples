Feature: 2 Gherkin Keywords 
Gherkin uses a set of special keywords to give structure and meaning to executable specifications. 
Each keyword is translated to many spoken languages; in this reference we’ll use English, but we also support [**other languages**](<LivingDoc.Demo/1 LivingDoc Features/1.1 Using the Gherkin Language/1.1.1 Using the Gherkin Language in different languages/5 Other supported languages.feature>).

The primary keywords are:
- Feature
- Rule (as of Gherkin 6)
- Example (or Scenario)
- Given, When, Then, And, But for steps (or *)
- Background
- Scenario Outline (or Scenario Template)
- Examples

Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120