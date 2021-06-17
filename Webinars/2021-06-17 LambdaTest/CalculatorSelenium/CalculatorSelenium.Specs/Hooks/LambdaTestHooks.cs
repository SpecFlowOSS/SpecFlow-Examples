using System;
using System.Security.Cryptography;
using System.Text;
using CalculatorSelenium.Specs.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace CalculatorSelenium.Specs.Hooks
{
    [Binding]
    class LambdaTestHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly BrowserDriver _browserDriver;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        private readonly LambdaTestCredentials _lambdaTestCredentials;
        private readonly TargetConfiguration _targetConfiguration;

        public LambdaTestHooks(ScenarioContext scenarioContext, BrowserDriver browserDriver, ISpecFlowOutputHelper specFlowOutputHelper, LambdaTestCredentials lambdaTestCredentials,
            TargetConfiguration targetConfiguration)
        {
            _scenarioContext = scenarioContext;
            _browserDriver = browserDriver;
            _specFlowOutputHelper = specFlowOutputHelper;
            _lambdaTestCredentials = lambdaTestCredentials;
            _targetConfiguration = targetConfiguration;
        }

        [AfterScenario()]
        public void MarkAsFailed()
        {
            if (_scenarioContext.ScenarioExecutionStatus != ScenarioExecutionStatus.OK)
            {
                ((IJavaScriptExecutor)_browserDriver.Current).ExecuteScript("lambda-status=failed");
            }
        }

        [AfterScenario()]
        public void LinkToVideo()
        {
            if (_browserDriver.Current is RemoteWebDriver remoteWebDriver && !string.IsNullOrWhiteSpace(_targetConfiguration.Name))
            {
                var linkToVideo = $"https://automation.lambdatest.com/logs/?testID={remoteWebDriver.SessionId}";

                _specFlowOutputHelper.AddAttachment(linkToVideo);
            }
        }
        
    }
}
