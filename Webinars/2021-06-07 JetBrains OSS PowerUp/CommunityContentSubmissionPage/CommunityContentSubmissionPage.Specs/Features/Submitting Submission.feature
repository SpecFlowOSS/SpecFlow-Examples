Feature: Submitting Content Suggestions with Privacy Policy

    Scenario: Content Suggestion is saved when submitting with accepted privacy policy

        Given the following content suggestions exist
          | Url | Type | Email | Description |

        And the content suggestion page is opened and filled with
          | Label          | Value                    |
          | Url            | https://www.specflow.org |
          | Type           | Blog Posts               |
          | Email          | youremail@example.org    |
          | Description    | Test Input               |
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
        But '<Field>' is left out

        When the form is submitted

        Then the following saved content suggestion exist
          | Url | Type | Email | Description |

        And the content suggestion form is still filled
        And the following error '<Error Message>' is shown for field '<Field>'

        Examples:
          | Field          | Error Message                       |
          | Name           | The Name field is required.         |
          | Privacy Policy | You must accept the privacy policy! |