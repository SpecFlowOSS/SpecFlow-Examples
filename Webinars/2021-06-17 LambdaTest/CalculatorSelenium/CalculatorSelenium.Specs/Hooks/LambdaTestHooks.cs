using System;
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

        public LambdaTestHooks(ScenarioContext scenarioContext, BrowserDriver browserDriver, ISpecFlowOutputHelper specFlowOutputHelper, LambdaTestCredentials lambdaTestCredentials)
        {
            _scenarioContext = scenarioContext;
            _browserDriver = browserDriver;
            _specFlowOutputHelper = specFlowOutputHelper;
            _lambdaTestCredentials = lambdaTestCredentials;
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
            var remoteWebDriver = _browserDriver.Current as RemoteWebDriver;
            var authToken = Convert.ToBase64String(new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(System.Text.Encoding.UTF8.GetBytes($"{_lambdaTestCredentials.Username}:{_lambdaTestCredentials.Accesskey}")));

            //var linkToVideo =  $"https://automation.lambdatest.com/public/video?testID={remoteWebDriver.SessionId}&auth={authToken}";
            var linkToVideo =  $"https://automation.lambdatest.com/logs/?testID={remoteWebDriver.SessionId}";


            _specFlowOutputHelper.AddAttachment(linkToVideo);
        }

        [AfterStep()]
        public void MakeScreenshot()
        {
            if (_browserDriver.Current is ITakesScreenshot screenshotTaker)
            {
                var screenshot = screenshotTaker.GetScreenshot();
            }
        }
    }
}
