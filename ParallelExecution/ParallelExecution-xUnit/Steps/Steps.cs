using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecsXUnit.Steps
{
    [Binding]
    public sealed class Steps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ISpecFlowOutputHelper _outputHelper;

        public Steps(ScenarioContext scenarioContext, ISpecFlowOutputHelper outputHelper)
        {
            _scenarioContext = scenarioContext;
            _outputHelper = outputHelper;
        }

        [Given(@"a step")]
        public void GivenAStep()
        {
            _outputHelper.WriteLine("Given at {0}", DateTime.Now);
            System.Threading.Thread.Sleep(1000);
        }
    }
}
