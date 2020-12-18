    using System;

    namespace LivingDoc.Demo.Support
{
    public class ConfigurationDriver
    {
        public string Mode => Environment.GetEnvironmentVariable("Mode");
    }
}