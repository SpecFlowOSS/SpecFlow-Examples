using System.Diagnostics;
using TechTalk.SpecFlow;

namespace SpecFlowCalculator.Specs.Hooks
{
    [Binding]
    public sealed class EnvironmentSetupHooks
    {
        private static Process _process;

        [BeforeTestRun]
        public static void BeforeScenario()
        {
            _process = Process.Start(@"../../../../SpecFlowCalculator/bin/Debug/net6.0/SpecFlowCalculator.exe");
        }

        [AfterTestRun]
        public static void AfterScenario()
        {
            // Close() or Dispose() do not stop the process
            _process.Kill();
        }
    }
}