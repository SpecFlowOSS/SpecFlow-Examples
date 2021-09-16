using System.Diagnostics;
using System.IO;
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
            Directory.SetCurrentDirectory("../../../../SpecFlowCalculator/bin/Debug/net6.0/");

            _process = Process.Start("SpecFlowCalculator.exe");
        }

        [AfterTestRun]
        public static void AfterScenario()
        {
            // Close() or Dispose() do not stop the process
            _process.Kill();
        }
    }
}