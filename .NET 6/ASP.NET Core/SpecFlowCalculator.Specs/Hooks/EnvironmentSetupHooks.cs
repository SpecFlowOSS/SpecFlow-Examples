using System.Diagnostics;
using TechTalk.SpecFlow;

namespace SpecFlowCalculator.Specs.Hooks
{
    [Binding]
    public sealed class EnvironmentSetupHooks
    {
        private static Process _webApp;

        [BeforeTestRun]
        public static void BeforeScenario()
        {
            _webApp = Process.Start(@"C:\Users\jorwe\source\repos\SpecFlow-Examples\.NET 6\ASP.NET Core\SpecFlowCalculator\bin\Debug\net6.0\SpecFlowCalculator.exe");
        }

        [AfterTestRun]
        public static void AfterScenario()
        {
            _webApp.Dispose();
        }
    }
}
