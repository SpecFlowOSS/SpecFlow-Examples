using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace CommunityContentSubmissionPage.Specs.Hooks
{
    //[Binding]
    public class AllHooks
    {
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public AllHooks(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        [BeforeFeature()]
        public static void BeforeFeature(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            specFlowOutputHelper.WriteLine("BeforeFeature");
        }

        [BeforeScenario()]
        public void BeforeScenario()
        {
            _specFlowOutputHelper.WriteLine("BeforeScenario");
        }


        [BeforeScenarioBlock()]
        public void BeforeScenarioBlock()
        {
            _specFlowOutputHelper.WriteLine("BeforeScenarioBlock");
        }

        [BeforeStep()]
        public void BeforeStep()
        {
            _specFlowOutputHelper.WriteLine("BeforeStep");
        }

        [AfterStep()]
        public void AfterStep()
        {
            _specFlowOutputHelper.WriteLine("AfterStep");
        }

        [AfterScenarioBlock()]
        public void AfterScenarioBlock()
        {
            _specFlowOutputHelper.WriteLine("AfterScenarioBlock");
        }

        [AfterScenario()]
        public void AfterScenario()
        {
            _specFlowOutputHelper.WriteLine("AfterScenario");
        }

        [AfterFeature()]
        public static void AfterFeature(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            specFlowOutputHelper.WriteLine("AfterFeature");
        }
    }
}
