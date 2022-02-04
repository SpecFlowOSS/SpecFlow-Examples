using OpenQA.Selenium;
using SpecFlow.Actions.Selenium;

namespace Example.PageObjects
{
    /// <summary>
    /// Calculator Page Object
    /// </summary>
    public class CalculatorPageObject : CalculatorElementLocators
    {
        private readonly IBrowserInteractions _browserInteractions;

        private IWebElement FirstNumber => _browserInteractions.WaitAndReturnElement(FirstNumberFieldLocator);
        private IWebElement SecondNumber => _browserInteractions.WaitAndReturnElement(SecondNumberFieldLocator);
        private IWebElement AddButton => _browserInteractions.WaitAndReturnElement(AddButtonLocator);
        private IWebElement Result => _browserInteractions.WaitAndReturnElement(ResultLabelLocator);
        private IWebElement ResetButton => _browserInteractions.WaitAndReturnElement(ResetButtonLocator);

        public CalculatorPageObject(IBrowserInteractions browserInteractions)
        {
            _browserInteractions = browserInteractions;
        }

        public void EnterFirstNumber(string number)
        {
            //Enter text
            FirstNumber.SendKeysWithClear(number);
        }

        public void EnterSecondNumber(string number)
        {
            //Enter text
            SecondNumber.SendKeysWithClear(number);
        }

        public void ClickAdd()
        {
            //Click the add button
            AddButton.ClickWithRetry();
        }

        public void EnsureCalculatorIsOpenAndReset()
        {
            //Open the calculator page in the browser if not opened yet
            if (_browserInteractions.GetUrl() != CalculatorUrl)
            {
                _browserInteractions.GoToUrl(CalculatorUrl);
            }
            //Otherwise reset the calculator by clicking the reset button
            else
            {
                //Click the rest button
                ResetButton.ClickWithRetry();

                //Wait until the result is empty again
                WaitForEmptyResult();
            }
        }

        public string? WaitForNonEmptyResult()
        {
            //Wait for the result to be not empty
            return _browserInteractions.WaitUntil(
                () => Result.GetAttribute("value"),
                result => !string.IsNullOrEmpty(result));
        }

        public string? WaitForEmptyResult()
        {
            //Wait for the result to be empty
            return _browserInteractions.WaitUntil(
                () => Result.GetAttribute("value"),
                result => result == string.Empty);
        }
    }
}