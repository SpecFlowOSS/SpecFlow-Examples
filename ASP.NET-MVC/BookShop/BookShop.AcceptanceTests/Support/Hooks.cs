using System.IO;
using BoDi;
using BookShop.AcceptanceTests.Drivers;
using BookShop.AcceptanceTests.Drivers.Integrated;
using BookShop.AcceptanceTests.Drivers.Selenium;
using BookShop.Mvc.Logic;
using BookShop.Mvc.Models;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
using TechTalk.SpecRun;

namespace BookShop.AcceptanceTests.Support
{
    [Binding]
    public class Hooks
    {
        private readonly TestRunContext _testRunContext;
        
        public Hooks(TestRunContext testRunContext)
        {
            _testRunContext = testRunContext;
        }

        [BeforeScenario(Order = 1)]
        public void RegisterDependencies(IObjectContainer objectContainer)
        {
            objectContainer.RegisterInstanceAs(new DatabaseContext());

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(_testRunContext.TestDirectory, "appsettings.json"), optional: true, reloadOnChange: true)
                .Build();

            objectContainer.RegisterInstanceAs(config);
            objectContainer.RegisterTypeAs<DatabaseContext, IDatabaseContext>();
            objectContainer.RegisterTypeAs<ShoppingCartLogic, IShoppingCartLogic>();
            objectContainer.RegisterTypeAs<BookLogic, IBookLogic>();

            var configurationDriver = new ConfigurationDriver();

            switch (configurationDriver.Mode)
            {
                case "Integrated":
                    objectContainer.RegisterTypeAs<IntegratedBookDetailsDriver, IBookDetailsDriver>();
                    objectContainer.RegisterTypeAs<IntegratedHomeDriver, IHomeDriver>();
                    objectContainer.RegisterTypeAs<IntegratedShoppingCartDriver, IShoppingCartDriver>();
                    objectContainer.RegisterTypeAs<IntegratedSearchDriver, ISearchDriver>();
                    objectContainer.RegisterTypeAs<IntegratedSearchResultDriver, ISearchResultDriver>();
                    break;
                case "Chrome":
                case "Chrome-Headless":
                case "Edge":
                case "Firefox":
                    objectContainer.RegisterTypeAs<SeleniumBookDetailsDriver, IBookDetailsDriver>();
                    objectContainer.RegisterTypeAs<SeleniumHomeDriver, IHomeDriver>();
                    objectContainer.RegisterTypeAs<SeleniumShoppingCartDriver, IShoppingCartDriver>();
                    objectContainer.RegisterTypeAs<SeleniumSearchDriver, ISearchDriver>();
                    objectContainer.RegisterTypeAs<SeleniumSearchResultDriver, ISearchResultDriver>();
                    break;
            }
        }
    }
}
