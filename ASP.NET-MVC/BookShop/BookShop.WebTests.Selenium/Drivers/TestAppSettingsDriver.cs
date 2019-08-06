using Microsoft.Extensions.Configuration;

namespace BookShop.WebTests.Selenium.Drivers
{
    public class TestAppSettingsDriver
    {
        private readonly IConfiguration _config;

        public TestAppSettingsDriver()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public string GetValue(string key)
        {
            return _config[key];
        }

        public void LoadAppSettings()
        {

        }
    }
}
