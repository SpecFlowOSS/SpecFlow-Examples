using System;
using System.IO;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using TechTalk.SpecFlow.TestFramework;

namespace SpecFlowCalculator.Specs.Drivers
{
    public class AppDriver : IDisposable
    {
        private readonly Lazy<AndroidDriver<AndroidElement>> _lazyAndroidDriver;
        private AppiumLocalService _appiumLocalService;

        public AndroidDriver<AndroidElement> Current => _lazyAndroidDriver.Value;

        public AppDriver(ITestRunContext testRunContext)
        {
            var appiumOptions = new AppiumOptions();

            appiumOptions.AddAdditionalCapability("automationName", "UiAutomator2");
            appiumOptions.AddAdditionalCapability("platformName", "Android");
            appiumOptions.AddAdditionalCapability("platformVersion", "11.0");
            appiumOptions.AddAdditionalCapability("deviceName", "Pixel XL");
            appiumOptions.AddAdditionalCapability("app", "C:/Users/jorwe/source/repos/SpecFlow-Examples/.NET 6/Android Mobile App/SpecFlowCalculator/bin/Debug/com.companyname.specflowcalculator.apk");
            appiumOptions.AddAdditionalCapability("avd", "pixel_3a_xl_r_11_0_-_api_30");


            //_appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();

            //_appiumLocalService.Start();

            _lazyAndroidDriver =
                new Lazy<AndroidDriver<AndroidElement>>(new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), appiumOptions));
        }

        public void Dispose()
        {
            if (_appiumLocalService.IsRunning)
            {
                _appiumLocalService.Dispose();
            }

            if (_lazyAndroidDriver.IsValueCreated)
            {
                Current.Close();
            }
        }
    }
}