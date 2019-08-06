using System;
using System.Collections.Generic;
using System.Text;
using BoDi;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeTestRun]
        public static void RegisterDependencies(IObjectContainer objectContainer)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            objectContainer.RegisterInstanceAs(config);
        }
    }
}
