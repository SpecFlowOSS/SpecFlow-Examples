    using System;
using Microsoft.Extensions.Configuration;

namespace BookShop.AcceptanceTests.Support
{
    public class ConfigurationDriver
    {
        private readonly IConfiguration _configuration;
        private const string SeleniumBaseUrlConfigFieldName = "seleniumBaseUrl";
        public string Mode => Environment.GetEnvironmentVariable("Mode");

        public ConfigurationDriver(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string SeleniumBaseUrl => _configuration[SeleniumBaseUrlConfigFieldName];
    }
}