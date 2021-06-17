using System;

namespace CalculatorSelenium.Specs.Drivers
{
    public class LambdaTestCredentials
    {
        public string Username => Environment.GetEnvironmentVariable("LT_USERNAME");
        public string Accesskey => Environment.GetEnvironmentVariable("LT_ACCESS_KEY");
    }
}