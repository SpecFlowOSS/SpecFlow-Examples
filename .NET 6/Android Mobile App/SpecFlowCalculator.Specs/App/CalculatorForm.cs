using OpenQA.Selenium.Appium.Android;
using SpecFlow.Actions.Android.Driver;

namespace SpecFlowCalculator.Specs.App
{
    public class CalculatorForm
    {
        private readonly AndroidAppDriver _androidAppDriver;

        public CalculatorForm(AndroidAppDriver androidAppDriver)
        {
            _androidAppDriver = androidAppDriver;
        }

        public AndroidElement FirstNumberTextBox =>
            _androidAppDriver.Current.FindElementById("com.companyname.specflowcalculator:id/firstNumberTextBox");

        public AndroidElement SecondNumberTextBox =>
            _androidAppDriver.Current.FindElementById("com.companyname.specflowcalculator:id/secondNumberTextBox");

        public AndroidElement AddButton =>
            _androidAppDriver.Current.FindElementById("com.companyname.specflowcalculator:id/addButton");

        public AndroidElement SubtractButton =>
            _androidAppDriver.Current.FindElementById("com.companyname.specflowcalculator:id/subtractButton");

        public AndroidElement MultiplyButton =>
            _androidAppDriver.Current.FindElementById("com.companyname.specflowcalculator:id/multiplyButton");

        public AndroidElement DivideButton =>
            _androidAppDriver.Current.FindElementById("com.companyname.specflowcalculator:id/divideButton");

        public AndroidElement ResultTextBox =>
            _androidAppDriver.Current.FindElementById("com.companyname.specflowcalculator:id/resultTextBox");
    }
}