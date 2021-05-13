using System.IO;
using BoDi;
using LivingDoc.Demo.Drivers;
using LivingDoc.Demo.Drivers.Integrated;
using LivingDoc.Demo.Drivers.Selenium;
using BookShop.Mvc.Logic;
using BookShop.Mvc.Models;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecRun;

namespace LivingDoc.Demo.Support
{
    [Binding]
    public class Hooks
    {
        private readonly TestRunContext _testRunContext;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(TestRunContext testRunContext, ISpecFlowOutputHelper specFlowOutputHelper, ScenarioContext scenarioContext)
        {
            _testRunContext = testRunContext;
            _specFlowOutputHelper = specFlowOutputHelper;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario(Order = 1)]
        public void RegisterDependencies(IObjectContainer objectContainer)
        {
            objectContainer.RegisterInstanceAs(new DatabaseContext());

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(_testRunContext.TestDirectory, "appsettings.json"), optional: true,
                    reloadOnChange: true)
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

        [BeforeScenario, Scope(Scenario = "Cheapest 3 book should be listed on the home screen (failed)")]
        public void DisplayOutput()
        {
            _specFlowOutputHelper.WriteLine($"Initializing: {_scenarioContext.ScenarioInfo.Title}");
        }

        [AfterStep]
        public void DisplayErrorOutput()
        {
            if (_scenarioContext.StepContext.Status == ScenarioExecutionStatus.TestError)
            {
                _specFlowOutputHelper.WriteLine($"Additional information about the error: " + _scenarioContext.TestError.StackTrace[0..500]);
            }
        }
    }
}
