using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShop.WebTests.Selenium.Support;
using OpenQA.Selenium;

namespace BookShop.WebTests.Selenium.Drivers
{
    class ClickDriver
    {
        private readonly SeleniumController _seleniumController;

        public ClickDriver(SeleniumController seleniumController)
        {
            _seleniumController = seleniumController;
        }

        public void ClickButton(string buttonId)
        {
            _seleniumController.WebDriver.FindElements(By.Id(buttonId)).First().Click();

        }
    }
}
