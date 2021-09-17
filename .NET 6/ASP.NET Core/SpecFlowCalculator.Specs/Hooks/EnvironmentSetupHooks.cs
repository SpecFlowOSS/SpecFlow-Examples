using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Events;

namespace SpecFlowCalculator.Specs.Hooks
{
    [Binding]
    public sealed class EnvironmentSetupHooks
    {
        private static Process _process;

        private static bool started = false;

        private static int retries = 0;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Starting SpecFlowCalculator.exe...");

            _process = Process.Start("../../../../SpecFlowCalculator/bin/Debug/net6.0/SpecFlowCalculator.exe");

            Console.WriteLine("Polling SpecFlowCalculator.exe...");

            // Debug
            PollProcess();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            // Close() or Dispose() do not stop the process
            _process.Kill();
        }

        // Debug
        private static void PollProcess()
        {
            while (!started)
            {
                if (retries < 5)
                {
                    try
                    {
                        Process.GetProcessById(_process.Id);
                    }
                    catch (Exception e)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(5));
                        Console.WriteLine("Waiting for 5 seconds for process SpecFlowCalculator.exe...");
                        retries++;
                    } 
                }
                else
                {
                    throw new Exception("Process SpecFlowCalculator.exe failed to start");
                }

                started = true;
                Console.WriteLine("SpecFlowCalculator.exe started");
            }
        }
    }
}