using OpenQA.Selenium.Appium.Android;
using SpecFlowCalculator.Specs.Drivers;

namespace SpecFlowCalculator.Specs.App
{
    public class CalculatorForm
    {
        private readonly AppDriver _appDriver;

        public CalculatorForm(AppDriver appDriver)
        {
            _appDriver = appDriver;
        }

        public AndroidElement FirstNumberTextBox =>
            _appDriver.Current.FindElementById("android:id/firstNumberTextBox'");

        public AndroidElement SecondNumberTextBox =>
            _appDriver.Current.FindElementById("android:id/secondNumberTextBox'");

        public AndroidElement AddButton =>
            _appDriver.Current.FindElementById("android:id/addButton");

        public AndroidElement SubtractButton =>
            _appDriver.Current.FindElementById("android:id/subtractButton");

        public AndroidElement MultiplyButton =>
            _appDriver.Current.FindElementById("android:id/multiplyButton");

        public AndroidElement DivideButton =>
            _appDriver.Current.FindElementById("android:id/divideButton");

        public AndroidElement ResultTextBox =>
            _appDriver.Current.FindElementById("android:id/resultTextBox");
    }
}