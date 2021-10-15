using OpenQA.Selenium.Appium.Windows;
using SpecFlow.Actions.WindowsAppDriver;

namespace SpecFlowCalculator.Specs.CalculatorApp
{
    public class CalculatorFormElements
    {
        private readonly AppDriver _appDriver;

        public CalculatorFormElements(AppDriver appDriver)
        {
            _appDriver = appDriver;
        }

        public WindowsElement FirstNumberTextBox =>
            _appDriver.Current.FindElementByAccessibilityId("textBox_firstNumber");

        public WindowsElement SecondNumberTextBox =>
            _appDriver.Current.FindElementByAccessibilityId("textBox_secondNumber");

        public WindowsElement AddButton =>
            _appDriver.Current.FindElementByAccessibilityId("button_add");

        public WindowsElement SubtractButton =>
            _appDriver.Current.FindElementByAccessibilityId("button_subtract");

        public WindowsElement MultiplyButton =>
            _appDriver.Current.FindElementByAccessibilityId("button_multiply");

        public WindowsElement DivideButton =>
            _appDriver.Current.FindElementByAccessibilityId("button_divide");

        public WindowsElement ResultTextBox =>
            _appDriver.Current.FindElementByAccessibilityId("textBox_result");
    }
}