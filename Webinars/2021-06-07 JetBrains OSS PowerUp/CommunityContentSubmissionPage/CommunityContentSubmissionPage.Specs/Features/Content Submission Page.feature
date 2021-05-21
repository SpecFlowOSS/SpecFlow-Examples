Feature: Content Suggestion Page

Scenario: Title is set to SpecFlow Community Content Submission

	When the submission page is opened

	Then the title of the page is 'SpecFlow Community Content Submission'

Scenario Outline: Input fields for content suggestions are available

	When the submission page is opened

	Then it is possible to enter a '<Input Name>' with label '<Label>'

	Examples:
		| Input Name  | Label              |
		| Url         | Url to Content     |
		| Type        | Type of Content    |
		| Email       | Your Email address |
		| Description | Description        |
		| Name        | Name               |

Scenario: Input field 'Type' offers a list of unique entries

	When the submission page is opened

	Then you can choose from the following types:
		| Typename      |
		| Blog Posts    |
		| Books         |
		| Presentations |
		| Videos        |
		| Podcasts      |
		| Examples      |

Scenario: Form is reset to default values with reset button

	Given the submission page is opened
	And the submission entry form is filled
	And the privacy policy is accepted
	
	When the form is reset

	Then every input is set to
		| Label       | Value      |
		| Url         |            |
		| Type        | Blog Posts |
		| Email       |            |
		| Description |            |
		| Name        |            |
	And the privacy policy is not accepted	


