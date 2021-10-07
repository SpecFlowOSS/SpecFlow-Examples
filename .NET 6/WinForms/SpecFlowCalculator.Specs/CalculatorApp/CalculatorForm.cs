using SpecFlow.Actions.WindowsAppDriver;

namespace SpecFlowCalculator.Specs.CalculatorApp
{
    public class CalculatorForm : CalculatorFormElements
    {
        public CalculatorForm(AppDriver appDriver) : base(appDriver)
        {
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

        public void ClickMultiply()
        {
            MultiplyButton.Click();
        }

        public void ClickDivide()
        {
            DivideButton.Click();
        }

        public string GetResult()
        {
            return ResultTextBox.Text;
        }
    }
}