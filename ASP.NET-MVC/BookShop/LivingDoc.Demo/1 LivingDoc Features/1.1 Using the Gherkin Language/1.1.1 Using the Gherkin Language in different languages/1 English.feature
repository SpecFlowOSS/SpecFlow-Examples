﻿# language: en
Feature: 1 English
The example comes from [**here**](https://github.com/cucumber/cucumber-ruby/blob/master/examples/i18n/en/features/addition.feature).

Scenario Outline: Add two numbers
	Given I have entered <input_1> into the calculator
	And I have entered <input_2> into the calculator
	When I press <button>
	Then the result should be <output> on the screen

	Examples:
		| input_1 | input_2 | button | output |
		| 20      | 30      | add    | 50     |
		| 2       | 5       | add    | 7      |
		| 0       | 40      | add    | 40     |