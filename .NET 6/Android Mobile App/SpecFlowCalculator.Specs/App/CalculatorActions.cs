using SpecFlowCalculator.Specs.Drivers;

namespace SpecFlowCalculator.Specs.App
{
    public class CalculatorActions : CalculatorForm
    {
        private readonly AppDriver _appDriver;

        public CalculatorActions(AppDriver appDriver) : base(appDriver)
        {
            _appDriver = appDriver;
        }

        public void EnterFirstNumber(string number)
        {
            FirstNumberTextBox.SendKeys(number);
        }

        public void EnterSecondNumber(string number)
        {
            SecondNumberTextBox.SendKeys(number);
        }

        public void ClickAdd()
        {
            AddButton.Click();
        }

        public void ClickSubtract()
        {
            SubtractButton.Click();
        }

        public void ClickDivide()
        {
            DivideButton.Click();
        }

        public void ClickMultiply()
        {
            MultiplyButton.Click();
        }

        public string GetResult()
        {
            return ResultTextBox.Text;
        }
    }
}