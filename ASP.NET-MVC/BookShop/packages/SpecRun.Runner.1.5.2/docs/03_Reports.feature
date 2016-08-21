@Report
Feature: Reports
All about generating reports based on the result of the test run

Background: 
    Given I have a test project 'SpecRun.TestProject'
    And there is a specrun configuration file 'Default.srprofile' as
        """
        <?xml version="1.0" encoding="utf-16"?>
        <TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
            <Settings name="Test SpecRun Config" projectName="SpecRun Test Project" />
            <Execution stopAfterFailures="0" retryFor="None" />
            <TestAssemblyPaths>
                <TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
            </TestAssemblyPaths>
        </TestProfile>
        """
    And the report file is configured to 'TestRunReport.html'

Scenario: Configuration information should be included in the report
    Given I have a feature file with a scenario as
        """
        Feature: Simple Feature
        Scenario: Simple Scenario
            When I do something
        """
    And all steps are bound and pass
    When I execute the tests through the console runner
    Then there should be a report 'TestRunReport.html' generated
    And the report should contain 'Test SpecRun Config'
    And the report should contain 'SpecRun Test Project'
    And the report should contain 'SpecRun.TestProject.dll'

Scenario: Success rate should be included in the report
    Given I have a feature file with 3 passing 1 failing and 0 pending scenarios
    When I execute the tests through the console runner
    Then there should be a report 'TestRunReport.html' generated
    And the report should contain '75%'

Scenario: Should handle many tests
    Given I have a feature file with 75 passing 20 failing and 5 pending scenarios
    And there is a specrun configuration file 'Default.srprofile' as
        """
        <?xml version="1.0" encoding="utf-8"?>
        <TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
            <Execution retryFor="Failing" retryCount="3" stopAfterFailures="0" />
            <TestAssemblyPaths>
                <TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
            </TestAssemblyPaths>
        </TestProfile>
        """
    When I execute the tests through the console runner
    Then there should be a report 'TestRunReport.html' generated
    And the report should contain '75%'

Scenario: Console output of the test should be displayed in the report
    Given I have a feature file with a scenario as
        """
        Feature: Simple Feature
        Scenario: Simple Scenario
            When I do something
        """
    And the following bindings
        """
        [When("I do something")]public void Do()
        {
            Console.WriteLine("Sample text on console out");
        }
        """
    When I execute the tests through the console runner
    Then there should be a report 'TestRunReport.html' generated
    And the report should contain 'Sample text on console out'

Scenario: Console error of the test should be displayed in the report with a prefix
    Given I have a feature file with a scenario as
        """
        Feature: Simple Feature
        Scenario: Simple Scenario
            When I do something
        """
    And the following bindings
        """
        [When("I do something")]public void Do()
        {
            Console.Error.WriteLine("Sample text on console error");
        }
        """
    When I execute the tests through the console runner
    Then there should be a report 'TestRunReport.html' generated
    And the report should contain '[ERR]Sample text on console error'

Scenario: Scenario steps should be displayed in the report
    Given I have a feature file with a scenario as
        """
        Feature: Simple Feature
        Scenario: Simple Scenario
            When I do something
        """
    And all steps are bound and pass
    When I execute the tests through the console runner
    Then there should be a report 'TestRunReport.html' generated
    And the report should contain 'When I do something'

Scenario: Scenario tags should be displayed in the report
    Given I have a feature file with a scenario as
        """
        Feature: Simple Feature
        @tag1 @tag2
        Scenario: Simple Scenario
            When I do something
        """
    And all steps are bound and pass
    When I execute the tests through the console runner
    Then there should be a report 'TestRunReport.html' generated
    And the report should contain 'tags: tag1, tag2'

Scenario: Should be able to use custom render template
    Given I have a feature file with a scenario as
        """
        Feature: Simple Feature
        Scenario: Simple Scenario
            When I do something
        """
    And all steps are bound and pass
    And there is a custom report template file 'CustomReportTemplate.cshtml' as
        """
        Custom report with @Model.Summary.Total test(s)
        """
    And there is a specrun configuration file 'Default.srprofile' as
        """
        <?xml version="1.0" encoding="utf-16"?>
        <TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
            <Settings reportTemplate="CustomReportTemplate.cshtml" />
            <TestAssemblyPaths>
                <TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
            </TestAssemblyPaths>
        </TestProfile>
        """
    When I execute the tests through the console runner
    Then there should be a report 'TestRunReport.html' generated
    And the report should contain 'Custom report with 1 test(s)'
    
Scenario: Report is in output folder
    Given there is a specrun configuration file 'Default.srprofile' as
        """
        <?xml version="1.0" encoding="utf-16"?>
        <TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
            <Settings name="Test SpecRun Config" projectName="SpecRun Test Project" outputFolder="..\Reports" />
            <Execution stopAfterFailures="0" retryFor="None" />
            <TestAssemblyPaths>
                <TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
            </TestAssemblyPaths>
        </TestProfile>
        """
    And I have a feature file with a scenario as
        """
        Feature: Simple Feature
        Scenario: Simple Scenario
            When I do something
        """
    And all steps are bound and pass
    When I execute the tests through the console runner
    Then there should be a report '..\Reports\TestRunReport.html' generated

Scenario: Filelink in Output is changed to hyperlink
	Given I have a feature file with a scenario as
		"""
		Feature: Simple Feature
		Scenario: Simple Scenario
			When I do something
		"""
	And the following bindings
		"""
		[When("I do something")]public void Do()
		{
			Console.WriteLine("file:///" + this.GetType().Assembly.Location);
		}
		"""
	When I execute the tests through the console runner
	Then there should be a report 'TestRunReport.html' generated
	And the report should contain '<a href='SpecRun.TestProject.dll'>SpecRun.TestProject.dll</a>'


Scenario: Report is in output folder and base folder
    Given there is a specrun configuration file 'Default.srprofile' as
        """
        <?xml version="1.0" encoding="utf-16"?>
        <TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
            <Settings name="Test SpecRun Config" projectName="SpecRun Test Project" outputFolder="..\Reports" />
            <Execution stopAfterFailures="0" retryFor="None" />
            <Report copyAlsoToBaseFolder="true"/>
            <TestAssemblyPaths>
                <TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
            </TestAssemblyPaths>
        </TestProfile>
        """
    And I have a feature file with a scenario as
        """
        Feature: Simple Feature
        Scenario: Simple Scenario
            When I do something
        """
    And all steps are bound and pass
    When I execute the tests through the console runner
    Then there should be a report '..\Reports\TestRunReport.html' generated
    And there should be a report 'TestRunReport.html' generated

Scenario: Disable report generation
    Given there is a specrun configuration file 'Default.srprofile' as
        """
        <?xml version="1.0" encoding="utf-16"?>
        <TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
            <Settings name="Test SpecRun Config" projectName="SpecRun Test Project" />
            <Report disable="true"/>
            <TestAssemblyPaths>
                <TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
            </TestAssemblyPaths>
        </TestProfile>
        """
    And I have a feature file with a scenario as
        """
        Feature: Simple Feature
        Scenario: Simple Scenario
            When I do something
        """
    And all steps are bound and pass
    When I execute the tests through the console runner
    Then there should be no report 'TestRunReport.html'

Scenario: Multiple report templates defined
    Given there is a specrun configuration file 'Default.srprofile' as
        """
        <?xml version="1.0" encoding="utf-16"?>
        <TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
            <Settings name="Test SpecRun Config" projectName="SpecRun Test Project" />
            <Report>
                <Template name="CustomReportTemplate_1.cshtml" />
                <Template name="CustomReportTemplate_2.cshtml" />
            </Report>
            <TestAssemblyPaths>
                <TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
            </TestAssemblyPaths>
        </TestProfile>
        """
    And there is a custom report template file 'CustomReportTemplate_1.cshtml' as
        """
        Custom report 1 with @Model.Summary.Total test(s)
        """
    And there is a custom report template file 'CustomReportTemplate_2.cshtml' as
        """
        Custom report 2 with @Model.Summary.Total test(s)
        """

    And I have a feature file with a scenario as
        """
        Feature: Simple Feature
        Scenario: Simple Scenario
            When I do something
        """
    And all steps are bound and pass
    
    When I execute the tests through the console runner
    
    Then there should be a report 'CustomReportTemplate_1.html' generated
    And the report should contain 'Custom report 1 with 1 test(s)'

    And there should be a report 'CustomReportTemplate_2.html' generated
    And the report should contain 'Custom report 2 with 1 test(s)'

Scenario: Multiple times the same report template is defined
    Given there is a specrun configuration file 'Default.srprofile' as
        """
        <?xml version="1.0" encoding="utf-16"?>
        <TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
            <Settings name="Test SpecRun Config" projectName="SpecRun Test Project" />
            <Report>
                <Template name="CustomReportTemplate.cshtml" />
                <Template name="CustomReportTemplate.cshtml" />
            </Report>
            <TestAssemblyPaths>
                <TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
            </TestAssemblyPaths>
        </TestProfile>
        """
    And there is a custom report template file 'CustomReportTemplate.cshtml' as
        """
        Custom report 1 with @Model.Summary.Total test(s)
        """

    And I have a feature file with a scenario as
        """
        Feature: Simple Feature
        Scenario: Simple Scenario
            When I do something
        """
    And all steps are bound and pass
    
    When I execute the tests through the console runner
    
    Then there should be only one '*.html' report 

Scenario: Multiple times the same report template is defined - different outputName
report should be generated, if you use the same report template with different outputNames

    Given there is a specrun configuration file 'Default.srprofile' as
        """
        <?xml version="1.0" encoding="utf-16"?>
        <TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
            <Settings name="Test SpecRun Config" projectName="SpecRun Test Project" />
            <Report>
                <Template name="CustomReportTemplate.cshtml" outputName="Report1.html"/>
                <Template name="CustomReportTemplate.cshtml" outputName="Report2.html"/>
            </Report>
            <TestAssemblyPaths>
                <TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
            </TestAssemblyPaths>
        </TestProfile>
        """
    And there is a custom report template file 'CustomReportTemplate.cshtml' as
        """
        Custom report 1 with @Model.Summary.Total test(s)
        """

    And I have a feature file with a scenario as
        """
        Feature: Simple Feature
        Scenario: Simple Scenario
            When I do something
        """
    And all steps are bound and pass
    
    When I execute the tests through the console runner
    
    Then there should be a report 'Report1.html' generated
    And there should be a report 'Report2.html' generated


Scenario: Multiple report templates defined - no standard report is generated
    Given there is a specrun configuration file 'Default.srprofile' as
        """
        <?xml version="1.0" encoding="utf-16"?>
        <TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
            <Settings name="Test SpecRun Config" projectName="SpecRun Test Project" />
            <Report>
                <Template name="CustomReportTemplate_1.cshtml" />
                <Template name="CustomReportTemplate_2.cshtml" />
            </Report>
            <TestAssemblyPaths>
                <TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
            </TestAssemblyPaths>
        </TestProfile>
        """
    And there is a custom report template file 'CustomReportTemplate_1.cshtml' as
        """
        Custom report 1 with @Model.Summary.Total test(s)
        """
    And there is a custom report template file 'CustomReportTemplate_2.cshtml' as
        """
        Custom report 2 with @Model.Summary.Total test(s)
        """

    And I have a feature file with a scenario as
        """
        Feature: Simple Feature
        Scenario: Simple Scenario
            When I do something
        """
    And all steps are bound and pass
    
    When I execute the tests through the console runner
    
    Then there should be no report 'TestRunReport.html'

Scenario: Custom output name
    Given there is a specrun configuration file 'Default.srprofile' as
        """
        <?xml version="1.0" encoding="utf-16"?>
        <TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
            <Settings name="Test SpecRun Config" projectName="SpecRun Test Project" />
            <Report>
                <Template name="CustomReportTemplate_1.cshtml" outputName="CustomReport.txt" />
            </Report>
            <TestAssemblyPaths>
                <TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
            </TestAssemblyPaths>
        </TestProfile>
        """
    And there is a custom report template file 'CustomReportTemplate_1.cshtml' as
        """
        Custom report 1 with @Model.Summary.Total test(s)
        """

    And I have a feature file with a scenario as
        """
        Feature: Simple Feature
        Scenario: Simple Scenario
            When I do something
        """
    And all steps are bound and pass
    
    When I execute the tests through the console runner
    
    Then there should be a report 'CustomReport.txt' generated
    And the report should contain 'Custom report 1 with 1 test(s)'

Scenario: Old and new report configuration
    Given there is a specrun configuration file 'Default.srprofile' as
        """
        <?xml version="1.0" encoding="utf-16"?>
        <TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
            <Settings name="Test SpecRun Config" projectName="SpecRun Test Project" reportTemplate="OldConfigTemplate.cshtml" />
            <Report>
                <Template name="NewConfigTemplate.cshtml" />
            </Report>
            <TestAssemblyPaths>
                <TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
            </TestAssemblyPaths>
        </TestProfile>
        """
    And there is a custom report template file 'OldConfigTemplate.cshtml' as
        """
        Old Custom report with @Model.Summary.Total test(s)
        """
    And there is a custom report template file 'NewConfigTemplate.cshtml' as
        """
        New Custom report with @Model.Summary.Total test(s)
        """

    And I have a feature file with a scenario as
        """
        Feature: Simple Feature
        Scenario: Simple Scenario
            When I do something
        """
    And all steps are bound and pass
    
    When I execute the tests through the console runner
    
    Then there should be a report 'TestRunReport.html' generated
    And the report should contain 'Old Custom report with 1 test(s)'
        
    And there should be a report 'NewConfigTemplate.html' generated
    And the report should contain 'New Custom report with 1 test(s)'

Scenario: Old and new report configuration - same template
    Given there is a specrun configuration file 'Default.srprofile' as
        """
        <?xml version="1.0" encoding="utf-16"?>
        <TestProfile xmlns="http://www.specrun.com/schemas/2011/09/TestProfile">
            <Settings name="Test SpecRun Config" projectName="SpecRun Test Project" reportTemplate="ConfigTemplate.cshtml" />
            <Report>
                <Template name="ConfigTemplate.cshtml" />
            </Report>
            <TestAssemblyPaths>
                <TestAssemblyPath>SpecRun.TestProject.dll</TestAssemblyPath>
            </TestAssemblyPaths>
        </TestProfile>
        """
    And there is a custom report template file 'ConfigTemplate.cshtml' as
        """
        Custom report with @Model.Summary.Total test(s)
        """
    
    And I have a feature file with a scenario as
        """
        Feature: Simple Feature
        Scenario: Simple Scenario
            When I do something
        """
    And all steps are bound and pass
    
    When I execute the tests through the console runner
    
    Then there should be only one '*.html' report 
    

Scenario: Whitespaces are trimmed correct

    Given I have a feature file with a scenario as 
    """
    Feature: Calculator
       In order to avoid silly mistakes
       As a math idiot
       I want to be told the sum of two numbers

    @Tag1
    Scenario: Add two numbers

                  1.1       2.2        3.3
    Item 0        |---------|----------|
                            2          0
    Item 1        |---------|----------|
                            3          10   
    Item 2        |---------|----------|
                            X          A

                        1.1       2.2        3.3
                 Item 0 |---------|----------|
                                  2          0
                 Item 1 |---------|----------|
                                  3          10   
                 Item 2 |---------|----------|
                                  X          A


          X      X
    123456789

    START OF FORMATTING TEST
          1 tab
                 2 tabs
                        3 tabs
                              4 tabs
                                     5 tabs                                          

          Given I have entered 50 into the calculator
          And I have also entered 70 into the calculator
          When I press add
          Then the result should be 120 on the screen

    @Tag2 @Tag1
    Scenario: Subtract two numbers

          Given I have entered 70 into the calculator
          And I have also entered 50 into the calculator
          When I press subtract
          Then the result should be 20 on the screen

    """
    And all steps are bound and pass
    When I execute the tests through the console runner
    Then there should be a report 'TestRunReport.html' generated
    And the report should contain 
        """
        <pre>   In order to avoid silly mistakes
           As a math idiot
           I want to be told the sum of two numbers</pre>
        """
    And the report should contain
        """
        <pre>              1.1       2.2        3.3
        Item 0        |---------|----------|
                                2          0
        Item 1        |---------|----------|
                                3          10   
        Item 2        |---------|----------|
                                X          A
        """

    And the report should contain
        """
                            1.1       2.2        3.3
                     Item 0 |---------|----------|
                                      2          0
                     Item 1 |---------|----------|
                                      3          10   
                     Item 2 |---------|----------|
                                      X          A
        """

    And the report should contain
        """
              X      X
        123456789

        START OF FORMATTING TEST
              1 tab
                     2 tabs
                            3 tabs
                                  4 tabs
                                         5 tabs                                          </pre>
        """