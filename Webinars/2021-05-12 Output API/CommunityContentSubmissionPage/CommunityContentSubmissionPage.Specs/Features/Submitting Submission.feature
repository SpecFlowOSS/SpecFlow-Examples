Feature: Submitting Content Suggestions with Privacy Policy

Scenario: Content Suggestion is saved when submitting with accepted privacy policy

    Given the following content suggestions exist
        | Url | Type | Email | Description |
        
    And the content suggestion page is opened and filled with
        | Label          | Value                    |
        | Url            | https://www.specflow.org |
        | Type           | Blog Posts               |
        | Email          | example@example.org      |
        | Description    | foo                      |
        | Name           | Jane Doe                 |
        | Privacy Policy | Accepted                 |

    When the form is submitted

    Then the following content suggestions exist
        | Url                      | Type       | Email                 | Description |
        | https://www.specflow.org | Blog Posts | youremail@example.org | Test Input  |
      

Scenario Outline: Error when mandatory fields for submitting content are missing
        
    Given the following content suggestions exist
        | Url | Type | Email | Description |

    And a filled content suggestion page is opened
    But <input> is left out

    When the form is submitted

    Then the following saved content suggestion exist
        | Url | Type | Email | Description |
    
    And the content suggestion form is still filled (unchanged)
    And the following error "....." is shown for field '<input>'

        

Examples: 
    | input          |
    | Name           |
    | Privacy Policy |
