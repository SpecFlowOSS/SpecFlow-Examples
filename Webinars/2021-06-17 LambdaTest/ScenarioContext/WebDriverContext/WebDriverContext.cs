using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Configuration;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Specialized;
using TechTalk.SpecFlow.Tracing;
using  System.IO;
using System.Reflection;
using NUnit.Framework;
using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SpecFlowParallel
{
    [Binding]
    public sealed class WebDriverContext
    {
        private ScenarioContext _scenarioContext;
        private LambdaTestDriver LTDriver;
        private IWebDriver _driver;
		private readonly IObjectContainer _objectContainer;
		
		/* Advanced Options like registration of the Browser Instance using IObjectContainer
		 can be done in the Hooks constructor
		*/
        public WebDriverContext(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            LTDriver = new LambdaTestDriver(scenarioContext);
            scenarioContext["LTDriver"] = LTDriver;
			_objectContainer.RegisterInstanceAs<LambdaTestDriver>(LTDriver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            LTDriver.Cleanup();
        }
    }

    public class LambdaTestDriver
    {
        private IWebDriver driver;
        private ScenarioContext ScenarioContext;

        public LambdaTestDriver(ScenarioContext ScenarioContext)
        {
            this.ScenarioContext = ScenarioContext;
        }

        public IWebDriver Init()
        {
            driver = new ChromeDriver();
            return driver;
        }

        public void Cleanup()
        {
            Console.WriteLine("Test Should stop");
            driver.Quit();
        }
    }
}