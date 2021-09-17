using System;
using SpecFlow.Actions.Selenium;
using SpecFlowCalculator.Specs.PageObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;

namespace SpecFlowCalculator.Specs.Hooks
{
    [Binding]
    public sealed class TestExecutionHooks
    {
        [BeforeScenario]
        public void BeforeScenario(CalculatorPage calculatorPage, IBrowserInteractions browserInteractions)
        {
            calculatorPage.Goto();

            // Debug

            Console.WriteLine("Waiting for driver to have url https://localhost:5001/");

            browserInteractions.WaitUntil(browserInteractions.GetUrl, result => result.Equals("https://localhost:5001/"));
        }
    }
}