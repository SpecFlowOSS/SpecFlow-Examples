using OpenQA.Selenium;

namespace CalculatorSelenium.Specs.PageObjects
{
    public class CalculatorPageObject
    {
        private readonly IWebDriver _webDriver;

        public CalculatorPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        private IWebElement FirstNumberElement => _webDriver.FindElement(By.Id("first-number"));
        private IWebElement SecondNumberElement => _webDriver.FindElement(By.Id("second-number"));
        private IWebElement AddButtonElement => _webDriver.FindElement(By.Id("add-slow-button"));
        private IWebElement ResultElement => _webDriver.FindElement(By.Id("result"));

        public void EnterFirstNumber(string number)
        {
            FirstNumberElement.Clear();
            FirstNumberElement.SendKeys(number);
        }

        public void EnterSecondNumber(string number)
        {
            SecondNumberElement.Clear();
            SecondNumberElement.SendKeys(number);
        }

        public void Add()
        {
            AddButtonElement.Click();
        }

        public string GetResult()
        {
            return ResultElement.GetAttribute("value");
        }
    }
}
