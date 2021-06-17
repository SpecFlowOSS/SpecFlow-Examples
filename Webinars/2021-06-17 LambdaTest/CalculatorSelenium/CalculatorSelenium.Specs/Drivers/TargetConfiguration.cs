using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorSelenium.Specs.Drivers
{
    public class TargetConfiguration
    {
        public string Browser => Environment.GetEnvironmentVariable("Test_Browser");
        public string OperatingSystem => Environment.GetEnvironmentVariable("Test_OS");

        public string Name => Environment.GetEnvironmentVariable("Test_Name");
    }
}
