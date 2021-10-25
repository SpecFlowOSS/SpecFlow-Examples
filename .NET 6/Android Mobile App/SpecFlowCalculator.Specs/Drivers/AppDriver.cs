using System;
using System.IO;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
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

            appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UiAutomator2");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "11.0");
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.companyname.specflowcalculator");
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "crc6451aad8f0eac5360f.MainActivity");


            //_appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();

            //_appiumLocalService.Start();

            _lazyAndroidDriver =
                new Lazy<AndroidDriver<AndroidElement>>(new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), appiumOptions, TimeSpan.FromSeconds(60)));
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