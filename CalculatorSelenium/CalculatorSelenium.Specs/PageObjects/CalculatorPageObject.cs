using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CalculatorSelenium.Specs.PageObjects
{
    public class CalculatorPageObject
    {
        private const string CalculatorUrl = "https://specflowoss.github.io/Calculator-Demo/Calculator.html";

        private readonly IWebDriver _webDriver;
        public const int DefaultWaitInSeconds = 5;

        public CalculatorPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        //Find elements by ID
        private IWebElement FirstNumberElement => _webDriver.FindElement(By.Id("first-number"));
        private IWebElement SecondNumberElement => _webDriver.FindElement(By.Id("second-number"));
        private IWebElement AddButtonElement => _webDriver.FindElement(By.Id("add-button"));
        private IWebElement ResultElement => _webDriver.FindElement(By.Id("result"));

        private IWebElement ResetButtonElement => _webDriver.FindElement(By.Id("reset-button"));

        public void EnterFirstNumber(string number)
        {
            //Clear text box
            FirstNumberElement.Clear();
            //Enter text
            FirstNumberElement.SendKeys(number);
        }

        public void EnterSecondNumber(string number)
        {
            //Clear text box
            SecondNumberElement.Clear();
            //Enter text
            SecondNumberElement.SendKeys(number);
        }

        public void ClickAdd()
        {
            //Click the add button
            AddButtonElement.Click();
        }

        public void EnsureCalculatorIsOpenAndReset()
        {
            //Open the calculator page in the browser if not opened yet
            if (_webDriver.Url != CalculatorUrl)
            {
                _webDriver.Url = CalculatorUrl;
            }
            //Otherwise reset the calculator by clicking the reset button
            else
            {
                //Click the rest button
                ResetButtonElement.Click();

                //Wait until the result is empty again
                WaitForEmptyResult();
            }
        }

        public string WaitForNonEmptyResult()
        {
            //Wait for the result to be not empty
            return WaitUntil(
                () => ResultElement.GetAttribute("value"),
                result => !string.IsNullOrEmpty(result));
        }

        public string WaitForEmptyResult()
        {
            //Wait for the result to be empty
            return WaitUntil(
                () => ResultElement.GetAttribute("value"),
                result => result == string.Empty);
        }

        private T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultOk) where T: class
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
            return wait.Until(driver =>
            {
                var result = getResult();
                if (!isResultOk(result))
                    return default;

                return result;
            });

        }
    }
}
