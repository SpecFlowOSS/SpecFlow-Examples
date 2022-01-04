using System.Text.Json;

namespace DemoWebApp.Specs.Configuration
{
    public static class TestConfiguration
    {
        public const string JsonConfigurationFileName = "testsettings.json";

        static TestConfiguration()
        {
            try
            {
                var settingsFilePath = GetFilePath();
                var jsonConfig = File.ReadAllText(settingsFilePath!);
                Settings = JsonSerializer.Deserialize<TestConfigurationModel>(jsonConfig)!;
            }
            catch (Exception e)
            {
                throw new Exception("There was an issue loading the test settings configuration", e);
            }
        }

        public static TestConfigurationModel Settings { get; private set; }

        private static string? GetFilePath()
        {
            var specflowJsonFileInAppDomainBaseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, JsonConfigurationFileName);

            if (File.Exists(specflowJsonFileInAppDomainBaseDirectory))
            {
                return specflowJsonFileInAppDomainBaseDirectory;
            }

            var specflowJsonFileTwoDirectoriesUp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", JsonConfigurationFileName);

            if (File.Exists(specflowJsonFileTwoDirectoriesUp))
            {
                return specflowJsonFileTwoDirectoriesUp;
            }

            var specflowJsonFileInCurrentDirectory = Path.Combine(Environment.CurrentDirectory, JsonConfigurationFileName);

            if (File.Exists(specflowJsonFileInCurrentDirectory))
            {
                return specflowJsonFileInCurrentDirectory;
            }

            return null;
        }
    }
}