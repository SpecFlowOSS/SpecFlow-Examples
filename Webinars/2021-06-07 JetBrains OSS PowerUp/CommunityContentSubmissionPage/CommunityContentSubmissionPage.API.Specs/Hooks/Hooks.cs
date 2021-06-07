using CommunityContentSubmissionPage.Database;
using CommunityContentSubmissionPage.Test.Common;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
using ConfigurationProvider = CommunityContentSubmissionPage.Test.Common.ConfigurationProvider;

namespace CommunityContentSubmissionPage.API.Specs.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
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


        [BeforeScenario]
        public void RegisterDI()
        {
            _scenarioContext.ScenarioContainer.RegisterInstanceAs<IDatabaseContext>(GetDatabaseContext());
            _scenarioContext.ScenarioContainer.RegisterInstanceAs(RestClientProvider.GetRestClient());
        }


        [BeforeScenario]
        [AfterScenario]
        public void ResetDatabase()
        {
            var databaseContext = GetDatabaseContext();

            databaseContext.RemoveRange(databaseContext.SubmissionEntries);
            databaseContext.SaveChanges();
        }

        private static DatabaseContext GetDatabaseContext()
        {
            var config = ConfigurationProvider.LoadConfiguration();
            var connectionString = config.GetConnectionString("db");

            var databaseContext = new DatabaseContext {ConnectionString = connectionString};
            return databaseContext;
        }
    }
}