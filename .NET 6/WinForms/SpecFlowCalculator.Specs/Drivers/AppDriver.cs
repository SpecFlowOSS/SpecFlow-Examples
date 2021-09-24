using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace SpecFlowCalculator.Specs.Drivers
{
    public class AppDriver : IDisposable
    {
        private readonly string _driverUrl = "http://127.0.0.1:4723/";

        private readonly string _applicationPath = @"C:\Users\jorwe\source\repos\SpecFlow-Examples\.NET 6\WinForms\SpecFlowCalculator\bin\Debug\net6.0-windows\SpecFlowCalculator.exe";

        private readonly Lazy<WindowsDriver<WindowsElement>> _lazyDriver;

        public WindowsDriver<WindowsElement> Current => _lazyDriver.Value;

        public AppDriver()
        {
            var options = new AppiumOptions();

            options.AddAdditionalCapability("app", _applicationPath);

            var driver = new WindowsDriver<WindowsElement>(new Uri(_driverUrl), options);

            _lazyDriver = new Lazy<WindowsDriver<WindowsElement>>(driver);
        }

        public void Dispose()
        {
            _lazyDriver.Value.CloseApp();
        }
    }
}