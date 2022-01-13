using DemoWebApp.Specs.Configuration;
using Microsoft.Extensions.Hosting;
using TechTalk.SpecFlow.Infrastructure;

namespace DemoWebApp.Specs.Hooks
{
    [Binding]
    public sealed class EnvironmentSetup
    {
        private static IHost? _host;

        [BeforeTestRun(Order = 0)]
        public static void StartHost()
        {
            _host = Program.CreateHostBuilder(Array.Empty<string>()).UseContentRoot(Path.Combine(Environment.CurrentDirectory, "../../../../DemoWebApp")).Build();

            _host.Start();
        }

        [BeforeScenario()]
        public static void LogTestInfo(ISpecFlowOutputHelper _specFlowOutputHelper)
        {
            _specFlowOutputHelper.WriteLine($"Test execution started for environment: {TestConfiguration.Settings.TestEnvironment}, Domain: {TestConfiguration.Settings.Domain}");
        }

        [AfterTestRun]
        public static void StopHost()
        {
            _host?.StopAsync().Wait();
        }
    }
}