using System;
using System.IO;
using BoDi;
using BookShop.AcceptanceTests.Drivers;
using BookShop.AcceptanceTests.Drivers.Integrated;
using BookShop.AcceptanceTests.Drivers.Selenium;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
using TechTalk.SpecRun;

namespace BookShop.AcceptanceTests.Support
{
    [Binding]
    public class Hooks
    {
        private readonly TestRunContext _testRunContext;
        private readonly ConfigurationDriver _configurationDriver;

        public Hooks(TestRunContext testRunContext, ConfigurationDriver configurationDriver)
        {
            _testRunContext = testRunContext;
            _configurationDriver = configurationDriver;
        }

        [BeforeScenario(Order = 1)]
        public void RegisterDependencies(IObjectContainer objectContainer)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(_testRunContext.TestDirectory, "appsettings.json"), optional: true, reloadOnChange: true)
                .Build();

            objectContainer.RegisterInstanceAs(config);


            switch (_configurationDriver.Mode)
            {
                case "Integrated":
                    objectContainer.RegisterTypeAs<IntegratedBookDetailsDriver, IBookDetailsDriver>();
                    objectContainer.RegisterTypeAs<IntegratedHomeDriver, IHomeDriver>();
                    objectContainer.RegisterTypeAs<IntegratedShoppingCartDriver, IShoppingCartDriver>();
                    objectContainer.RegisterTypeAs<IntegratedSearchDriver, ISearchDriver>();
                    objectContainer.RegisterTypeAs<IntegratedSearchResultDriver, ISearchResultDriver>();
                    break;
                case "Chrome":
                    objectContainer.RegisterTypeAs<SeleniumBookDetailsDriver, IBookDetailsDriver>();
                    objectContainer.RegisterTypeAs<SeleniumHomeDriver, IHomeDriver>();
                    objectContainer.RegisterTypeAs<SeleniumShoppingCartDriver, IShoppingCartDriver>();
                    objectContainer.RegisterTypeAs<SeleniumSearchDriver, ISearchDriver>();
                    objectContainer.RegisterTypeAs<SeleniumSearchResultDriver, ISearchResultDriver>();
                    break;
            }
        }
    }


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
