using System;
using System.IO;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using TechTalk.SpecFlow.TestFramework;

namespace SpecFlowCalculator.Specs.Drivers
{
    public class AppDriver
    {
        private readonly ITestRunContext _testRunContext;
        private AppiumOptions _appiumOptions;
        private AppiumLocalService _appiumLocalService;

        private Lazy<AndroidDriver<AndroidElement>> _lazyAndroidDriver;

        public AndroidDriver<AndroidElement> Current => _lazyAndroidDriver.Value;

        public AppDriver(ITestRunContext testRunContext)
        {
            _testRunContext = testRunContext;
            _appiumOptions = new AppiumOptions();

            _appiumOptions.AddAdditionalCapability("automationName", "Appium");
            _appiumOptions.AddAdditionalCapability("platformName", "Android");
            _appiumOptions.AddAdditionalCapability("deviceName", "Android Emulator");
            _appiumOptions.AddAdditionalCapability("app", Path.Combine(_testRunContext.GetTestDirectory(), "SpecFlowCalculator/bin/Debug/com.companyname.specflowcalculator.apk"));


            _appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();

            _appiumLocalService.Start();

            _lazyAndroidDriver =
                new Lazy<AndroidDriver<AndroidElement>>(new AndroidDriver<AndroidElement>(_appiumLocalService, _appiumOptions));
        }
    }
}