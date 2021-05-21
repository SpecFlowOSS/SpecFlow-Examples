Feature: Submitting Submission

    Scenario: Input from submission is saved

    Assumption: There are no entries in the database

        Given the following submission entry
          | Label       | Value                    |
          | Url         | https://www.specflow.org |
          | Type        | Blog Posts               |
          | Email       | example@example.org      |
          | Description | foo                      |
          | Name        | Jane Doe                 |
        And the privacy policy is accepted

        When the submission entry is submitted
        Then there is 'one' submission entry stored

    Scenario: Entered values from submission page is saved

        Given the following submission entry
          | Label       | Value                    |
          | Url         | https://www.specflow.org |
          | Type        | Blog Posts               |
          | Email       | youremail@example.org    |
          | Description | Test Input               |
          | Name        | Jane Doe                 |
        And the privacy policy is accepted

        When the submission entry is submitted
        Then there is a submission entry stored with the following data:
          | Url                      | Type       | Email                 | Description |
          | https://www.specflow.org | Blog Posts | youremail@example.org | Test Input  |