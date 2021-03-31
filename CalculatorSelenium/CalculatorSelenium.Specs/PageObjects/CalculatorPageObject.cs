using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CalculatorSelenium.Specs.PageObjects
{
    public class CalculatorPageObject
    {
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
            //Click button
            AddButtonElement.Click();
        }

        public string WaitForNonEmptyResult()
        {
            Func<IWebDriver, string> func = driver => ResultElement.GetAttribute("value");
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
            return wait.Until(driver1 =>
            {
                var result = func(driver1);
                if (string.IsNullOrEmpty(result))
                    return null;

                return result;
            });
        }
    }
}
