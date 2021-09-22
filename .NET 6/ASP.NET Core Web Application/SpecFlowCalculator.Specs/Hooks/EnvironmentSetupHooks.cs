using System;
using System.IO;
using Microsoft.Extensions.Hosting;
using TechTalk.SpecFlow;

namespace SpecFlowCalculator.Specs.Hooks
{
    [Binding]
    public sealed class EnvironmentSetupHooks
    {
        private static IHost _host;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _host = Program.CreateHostBuilder(null).UseContentRoot(Path.Combine(Environment.CurrentDirectory, "../../../../SpecFlowCalculator")).Build();

            _host.Start();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _host.StopAsync().Wait();
        }
    }
}
