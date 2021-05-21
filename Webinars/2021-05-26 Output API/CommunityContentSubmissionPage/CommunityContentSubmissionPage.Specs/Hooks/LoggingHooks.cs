using System.IO;
using System.Linq;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace CommunityContentSubmissionPage.Specs.Hooks
{
    [Binding]
    public class LoggingHooks
    {
        private readonly Actor _actor;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public LoggingHooks(Actor actor, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _actor = actor;
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        [AfterStep()]
        public void MakeScreenshotAfterStep()
        {
            var screenshotLocation = _actor.AsksFor(CurrentScreenshot.SavedTo("Screenshots", Path.GetRandomFileName()));

            _specFlowOutputHelper.WriteLine($"Current URL: {_actor.AsksFor(CurrentUrl.FromBrowser())}"); 

            _specFlowOutputHelper.AddAttachment(screenshotLocation);
        }


        [BeforeScenario()]
        public void LogEntriesInDatabase()
        {
            var databaseContext = Hooks.GetDatabaseContext();

            _specFlowOutputHelper.WriteLine($"Number of Entries: {databaseContext.SubmissionEntries.Count()}");
        }
    }
}