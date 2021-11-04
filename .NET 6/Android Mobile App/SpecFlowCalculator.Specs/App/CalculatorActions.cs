using SpecFlow.Actions.Android.Driver;

namespace SpecFlowCalculator.Specs.App
{
    public class CalculatorActions : CalculatorForm
    {
        private readonly AndroidAppDriver _androidAppDriver;

        public CalculatorActions(AndroidAppDriver androidAppDriver) : base(androidAppDriver)
        {
            _androidAppDriver = androidAppDriver;
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