using System;
using TechTalk.SpecFlow;

namespace ScenarioFeatureContextInjection.Support
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }
               
        [BeforeScenario()]
        public void BeforeScenario()
        {

            Console.WriteLine("Starting " + scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario()]
        public void AfterScenario()
        {
            Console.WriteLine("Finished " + scenarioContext.ScenarioInfo.Title);
        }
        
        [BeforeFeature()]
        public static void BeforeFeature()
        {
            Console.WriteLine("Starting " + FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterFeature()]
        public static void AfterFeature()
        {
            Console.WriteLine("Finished " + FeatureContext.Current.FeatureInfo.Title);
        }
    }
}