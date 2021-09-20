using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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

            var logger = _host.Services.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("Content root: {contentRoot}", contentRoot);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _host.StopAsync().Wait();
        }
    }
}