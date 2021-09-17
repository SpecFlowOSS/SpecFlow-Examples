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
        public static void BeforeTestRun()
        {
            _process = Process.Start("../../../../SpecFlowCalculator/bin/Debug/net6.0/SpecFlowCalculator.exe");

            // Directory.SetCurrentDirectory(@"D:\a\1\s\.NET 6\ASP.NET Core\SpecFlowCalculator\obj\Debug\net6.0\SpecFlowCalculator.exe");

            // _process = Process.Start(@"D:\a\1\s\.NET 6\ASP.NET Core\SpecFlowCalculator\obj\Debug\net6.0\SpecFlowCalculator.exe");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            // Close() or Dispose() do not stop the process
            _process.Kill();
        }
    }
}