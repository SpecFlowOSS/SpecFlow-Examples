SpecFlow BookShop Sample
========================

This solution contains an end-to-end sample to show how to use SpecFlow for 
ASP.NET MVC applications.

You can find more information about SpecFlow at http://www.specflow.org/.

Prerequisites to run the application
====================================

- Visual Studio 2008 or Visual Studio 2010
- ASP.NET MVC2 RTM (only for Visual Studio 2008)
  (http://www.microsoft.com/downloads/details.aspx?displaylang=en&FamilyID=c9ba1fe1-3ba8-439a-9e21-def90a8615a9)
- Microsoft SQL Server 2005 or higher (any editions)
- SpecFlow 1.3 or higher (http://www.specflow.org/)
- Optionally: cuke4vs - syntax coloring and intellisense for SpecFlow files
  (http://github.com/henritersteeg/cuke4vs/downloads)

Setup Application
=================

- Create a database and initialize table structure by executing "create_db.sql" 
  script on your database server. (This scrip will create and setup a database 
  called "BookShop" in your database server.)
- Update connection string in the web.config file and all app.config files of 
  the different test projects. The default setting is 
  "Data Source=.;Initial Catalog=BookShop;Integrated Security=True;MultipleActiveResultSets=True", 
  you might need to change the data source if you use a database server not 
  running as a default instance of your local machine. The easiest way to 
  update all connection string is to perform a solution-wide search and replace, 
  e.g.:
    Data Source=.; -> Data Source=.\SQLEXPRESS;
  (You might want to restrict the replacements to the *.config files only 
  otherwise it will also replace it in this readme.txt file... :)
- Set the "BookShop" project as startup project and run the application. You 
  should see some books on the start page of the app. 

Upgrade Solution to VS2010
==========================

The solution can be upgraded to VS2010 with a few steps:
- Open solution in VS2010 and let Visual Studio upgrade the solution.
  Let the wizard upgrade all projects to .NET 4.0 (choose "yes").
- Upgrade the projects in the "Alternative Integrations" folder to .NET 4.0
  manually (change target framework in project properties). The upgrade wizard 
  in VS2010 RTM skips these projects unfortunately.
- Select the feature files in solution explorer and invoke "Run Custom Tool"
  command from the context menu (you can select multiple files within a 
  project).

There will be two warnings still in the BookShop.edmx file, but those can be 
ignored.

Execute Acceptance Tests
========================

With SpecFlow you can define the acceptance criteria in .feature files, that 
can be executed. The "BookShop.AcceptanceTests" contains the feature files for
this application. 
SpecFlow generated executable unit tests from the defined acceptance criteria 
(called scenarios), these generated unit tests are in the generated sub-items
if the feature files (e.g. US01_BookSearch.feature.cs).

The execution of the tests depends on the unit test provider used by SpecFlow 
(currently NUnit, MsTest and xUnit is supported). The unit test provider can
be configured in the app.config file of the test project:
  <specFlow>
    <unitTestProvider name="MsTest" />
  </specFlow>
  
The current sample used "MsTest" for the acceptance criteria in the 
"BookShop.AcceptanceTests" project. Therefore to execute the tests, you have to
perform the following steps:

- Select the project "BookShop.AcceptanceTests" in solution explorer.
- Select command from the main menu: Test / Run / Tests in Current Context 
  (Ctrl R,T)

If you have configured the application properly, all tests should pass.


Alternative Acceptance Test Integrations
========================================

Under the solution folder "Alternative Integrations" you will find other
alternatives how acceptance criteria can be automated. (The 
"BookShop.AcceptanceTests" automates the controller layer of the application.)

These alternative integrations are only implemented for a few selected 
scenarios so they do not provide full coverage of the application features.

BookShop.AcceptanceTests.Manual 
-------------------------------

This project shows how manual test can be included in the test execution. With 
the provided helper class, whenever a test step is annotated with "(manual)" 
suffix a popup window is shown to instruct the tester and capture the result.

The popup can be disabled (e.g. in build servers) by setting the environment
variable "DisableSpecFlowPopup" to "true".

BookShop.AcceptanceTests.Selenium
---------------------------------

This project shows how to automate acceptance criteria using a UI automation 
tool (in this case Selenium, http://seleniumhq.org/). 

To run these tests, you need to have a selenium remote control server running. 
Learn more about selenium remote control server here: 
http://seleniumhq.org/projects/remote-control/.

BookShop.AcceptanceTests.MvcIntegration
---------------------------------------

This project shows how to automate acceptance criteria using a self-hosted 
ASP.NET runtime.

See http://blog.stevensanderson.com/2009/06/ for more details.
