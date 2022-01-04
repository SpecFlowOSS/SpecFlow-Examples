using Microsoft.Extensions.Hosting;

namespace DemoWebApp.Specs.Hooks
{
    [Binding]
    public sealed class AppHooks
    {
        private static IHost? _host;

        [BeforeTestRun(Order = 0)]
        public static void BeforeTestRunAsync()
        {
            _host = Program.CreateHostBuilder(null).UseContentRoot(Path.Combine(Environment.CurrentDirectory, "../../../../DemoWebApp")).Build();

            _host.Start();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _host?.StopAsync().Wait();
        }
    }
}