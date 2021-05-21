using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boa.Constrictor.Logging;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using CommunityContentSubmissionPage.Business.Infrastructure;
using CommunityContentSubmissionPage.Database;
using CommunityContentSubmissionPage.Test.Common;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow.Infrastructure;
using ConfigurationProvider = CommunityContentSubmissionPage.Test.Common.ConfigurationProvider;

namespace CommunityContentSubmissionPage.Specs.Hooks
{
    [Binding]
    public class Hooks
    {
  
        private readonly ScenarioContext _scenarioContext;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public Hooks(ScenarioContext scenarioContext, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _scenarioContext = scenarioContext;
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        [BeforeTestRun]
        public static void DockerComposeUp()
        {
            DockerHandling.DockerComposeUp();
        }

        [AfterTestRun]
        public static void DockerComposeDown()
        {
            DockerHandling.DockerComposeDown();
        }


        [BeforeScenario(Order = 0)]
        public void RegisterDI()
        {
            _scenarioContext.ScenarioContainer.RegisterInstanceAs<IDatabaseContext>(GetDatabaseContext());

            var actor = new Actor("Chrome", new ConsoleLogger());
            actor.Can(BrowseTheWeb.With(new ChromeDriver()));

            
            _scenarioContext.ScenarioContainer.RegisterInstanceAs(actor);
        }

        [AfterScenario()]
        public void Cleanup()
        {
            var actor = _scenarioContext.ScenarioContainer.Resolve<Actor>();
            actor.AttemptsTo(QuitWebDriver.ForBrowser());
        }

        [BeforeScenario()]
        [AfterScenario()]
        public void ResetDatabase()
        {
            var databaseContext = GetDatabaseContext();


            databaseContext.RemoveRange(databaseContext.SubmissionEntries);
            databaseContext.SaveChanges();
        }

        public static DatabaseContext GetDatabaseContext()
        {
            var config = ConfigurationProvider.LoadConfiguration();
            var connectionString = config.GetConnectionString("db");

            var databaseContext = new DatabaseContext() {ConnectionString = connectionString};
            return databaseContext;
        }
    }
}
