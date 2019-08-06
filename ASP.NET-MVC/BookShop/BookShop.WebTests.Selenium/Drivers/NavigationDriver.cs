using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using BookShop.WebTests.Selenium.Support;
using OpenQA.Selenium;

namespace BookShop.WebTests.Selenium.Drivers
{
    public class NavigationDriver
    {
        private readonly SeleniumController _seleniumController;
        private readonly TestAppSettingsDriver _appSettingsDriver;

        public NavigationDriver(SeleniumController seleniumController, TestAppSettingsDriver appSettingsDriver)
        {
            _seleniumController = seleniumController;
            _appSettingsDriver = appSettingsDriver;
        }

        public void NavigateTo(string relativeUrl)
        {
            var baseUrl = _appSettingsDriver.GetValue("AppUrl");
            _seleniumController.WebDriver.Navigate().GoToUrl(new Uri(new Uri(baseUrl), relativeUrl));
        }
    }
}
