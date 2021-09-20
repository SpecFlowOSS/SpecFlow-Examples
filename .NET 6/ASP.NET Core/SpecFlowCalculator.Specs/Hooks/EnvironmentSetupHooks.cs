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
            var contentRoot = Path.Combine(Environment.CurrentDirectory, "../../../../SpecFlowCalculator");

            _host = Program.CreateHostBuilder(null).UseContentRoot(contentRoot).Build();

            _host.Start();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _host.StopAsync().Wait();
        }
    }
}