Feature: 4 Linking Work Items
As explained in the description of [Gherkin Tags](<BookShop.AcceptanceTests/1 LivingDoc Features/1.1 Using the Gherkin Language/9 Tags.feature>), Features and Scenarios can be tagged with individual tags. 
Another Feature of SpecFlow+ LivingDoc is that you can additionally **link issues/tickets/work items/etc**.

When using the Azure DevOps extension SpecFlow+ LivingDoc you can easily link items of your project. 
When using the SpecFlow+ LivingDoc Generator you can also link external ALM systems. 

Ýou can learn more how to set it up in the [documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/Viewing/Linking.html).

The following example describes a scenario that is tagged with a Work-Item link. 

@WI1
@WI3
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120