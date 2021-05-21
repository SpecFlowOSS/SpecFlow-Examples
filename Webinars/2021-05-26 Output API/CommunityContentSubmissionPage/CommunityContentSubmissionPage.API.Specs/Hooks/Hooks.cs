using CommunityContentSubmissionPage.Database;
using CommunityContentSubmissionPage.Test.Common;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using ConfigurationProvider = CommunityContentSubmissionPage.Test.Common.ConfigurationProvider;
using System.Linq;

namespace CommunityContentSubmissionPage.API.Specs.Hooks
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


        [BeforeScenario()]
        public void RegisterRestClient()
        {
            _scenarioContext.ScenarioContainer.RegisterInstanceAs(RestClientProvider.GetRestClient());
        }


        [BeforeScenario()]
        [AfterScenario()]
        public void ResetDatabase()
        {
            var config = ConfigurationProvider.LoadConfiguration();
            var connectionString = config.GetConnectionString("db");

            var databaseContext = new DatabaseContext(){ConnectionString = connectionString};


            databaseContext.RemoveRange(databaseContext.SubmissionEntries);
            databaseContext.SaveChanges();
        }

        
    }
}
