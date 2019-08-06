using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using BookShop.WebTests.Selenium.Support;
using OpenQA.Selenium;

namespace BookShop.WebTests.Selenium.Drivers
{
    class NavigationDriver
    {
        private readonly SeleniumController _seleniumController;

        public NavigationDriver(SeleniumController seleniumController)
        {
            _seleniumController = seleniumController;
        }

        public void NavigateTo(string relativeUrl)
        {
            _seleniumController.WebDriver.Navigate().GoToUrl(new Uri(new Uri(ConfigurationManager.AppSettings["AppUrl"]), relativeUrl));
        }
    }
}
