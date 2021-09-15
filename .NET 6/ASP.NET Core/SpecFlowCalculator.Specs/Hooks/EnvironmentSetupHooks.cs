using System.Diagnostics;
using TechTalk.SpecFlow;

namespace SpecFlowCalculator.Specs.Hooks
{
    [Binding]
    public sealed class EnvironmentSetupHooks
    {
        [BeforeTestRun]
        public static void BeforeScenario()
        {
            Process.Start(@"../../../../SpecFlowCalculator/bin/Debug/net6.0/SpecFlowCalculator.exe");
        }

        [AfterTestRun]
        public static void AfterScenario()
        {
            foreach (var runningProcess in Process.GetProcessesByName("SpecFlowCalculator.exe"))
            {
                runningProcess.Dispose();
            }
        }
    }
}
