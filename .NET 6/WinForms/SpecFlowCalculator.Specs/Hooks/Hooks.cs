using System.Diagnostics;
using TechTalk.SpecFlow;

namespace SpecFlowCalculator.Specs.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private static Process _process;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _process = Process.Start(@"C:\Program Files\Windows Application Driver\WinAppDriver.exe");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _process.Kill();
        }
    }
}
