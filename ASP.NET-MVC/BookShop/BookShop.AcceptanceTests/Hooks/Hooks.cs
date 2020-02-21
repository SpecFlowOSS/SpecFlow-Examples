using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BoDi;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
using TechTalk.SpecRun;

namespace BookShop.AcceptanceTests.Hooks
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
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(_testRunContext.TestDirectory, "appsettings.json"), optional: true, reloadOnChange: true)
                .Build();

            objectContainer.RegisterInstanceAs(config);
        }
    }
}
