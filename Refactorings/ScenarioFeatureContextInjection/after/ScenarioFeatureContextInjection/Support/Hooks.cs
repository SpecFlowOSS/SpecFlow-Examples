using System;
using TechTalk.SpecFlow;

namespace ScenarioFeatureContextInjection.Support
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine("Starting " + _scenarioContext.ScenarioInfo.Title);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Starting " + featureContext.FeatureInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Finished " + _scenarioContext.ScenarioInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Finished " + featureContext.FeatureInfo.Title);
        }
    }
}