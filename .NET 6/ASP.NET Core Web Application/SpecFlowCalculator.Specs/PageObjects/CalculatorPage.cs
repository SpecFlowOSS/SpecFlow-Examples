using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;

namespace SpecFlowCalculator.Specs.PageObjects
{
    public class CalculatorPage
    {
        private readonly IBrowserInteractions _browserInteractions;

        private const string PageUrl = "http://localhost:5000/";

        private IWebElement FirstNumber => _browserInteractions.WaitAndReturnElement(By.Id("firstNumber"));

        private IWebElement SecondNumber => _browserInteractions.WaitAndReturnElement(By.Id("secondNumber"));

        private IWebElement AddButton => _browserInteractions.WaitAndReturnElement(By.Id("add"));

        private IWebElement SubtractButton => _browserInteractions.WaitAndReturnElement(By.Id("subtract"));

        private IWebElement MultiplyButton => _browserInteractions.WaitAndReturnElement(By.Id("multiply"));

        private IWebElement DivideButton => _browserInteractions.WaitAndReturnElement(By.Id("divide"));

        private IWebElement Result => _browserInteractions.WaitAndReturnElement(By.Id("result"));

        public CalculatorPage(IBrowserInteractions browserInteractions)
        {
            _browserInteractions = browserInteractions;
        }

        public void Goto()
        {
            _browserInteractions.GoToUrl(PageUrl);
        }

        public void EnterFirstNumber(string number)
        {
            FirstNumber.SendKeysWithClear(number);
        }

        public void EnterSecondNumber(string number)
        {
            SecondNumber.SendKeysWithClear(number);
        }

        public void ClickAdd()
        {
            AddButton.ClickWithRetry();
        }

        public void ClickSubtract()
        {
            SubtractButton.ClickWithRetry();
        }

        public void ClickMultiply()
        {
            MultiplyButton.ClickWithRetry();
        }

        public void ClickDivide()
        {
            DivideButton.ClickWithRetry();
        }

        public bool ResultEquals(string result)
        {
            return Result.HasValue(result);
        }
    }
}
