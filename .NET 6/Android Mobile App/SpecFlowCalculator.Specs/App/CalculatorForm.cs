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
            _appDriver.Current.FindElementById("com.companyname.specflowcalculator:id/firstNumberTextBox");

        public AndroidElement SecondNumberTextBox =>
            _appDriver.Current.FindElementById("com.companyname.specflowcalculator:id/secondNumberTextBox");

        public AndroidElement AddButton =>
            _appDriver.Current.FindElementById("com.companyname.specflowcalculator:id/addButton");

        public AndroidElement SubtractButton =>
            _appDriver.Current.FindElementById("com.companyname.specflowcalculator:id/subtractButton");

        public AndroidElement MultiplyButton =>
            _appDriver.Current.FindElementById("com.companyname.specflowcalculator:id/multiplyButton");

        public AndroidElement DivideButton =>
            _appDriver.Current.FindElementById("com.companyname.specflowcalculator:id/divideButton");

        public AndroidElement ResultTextBox =>
            _appDriver.Current.FindElementById("com.companyname.specflowcalculator:id/resultTextBox");
    }
}