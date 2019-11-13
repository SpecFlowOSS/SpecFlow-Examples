using System;
using TechTalk.SpecFlow;

namespace ScenarioFeatureContextInjection.Support
{
    [Binding]
    public class Hooks
    {

        [BeforeScenario()]
        public void BeforeScenario()
        {
            Console.WriteLine("Starting " + ScenarioContext.Current.ScenarioInfo.Title);
        }

        [BeforeFeature()]
        public static void BeforeFeature()
        {
            Console.WriteLine("Starting " + FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterScenario()]
        public void AfterScenario()
        {
            Console.WriteLine("Finished " + ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterFeature()]
        public static void AfterFeature()
        {
            Console.WriteLine("Finished " + FeatureContext.Current.FeatureInfo.Title);
        }
    }
}