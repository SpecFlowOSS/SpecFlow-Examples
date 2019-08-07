using System;
using System.Collections.Generic;
using System.Text;
using BookShop.WebTests.Selenium.Support;
using OpenQA.Selenium;

namespace BookShop.WebTests.Selenium.Drivers
{
    public class FieldDriver
    {
        private readonly SeleniumController _seleniumController;
        private readonly FormDriver _formDriver;

        public FieldDriver(SeleniumController seleniumController, FormDriver formDriver)
        {
            _seleniumController = seleniumController;
            _formDriver = formDriver;
        }
        public IWebElement GetFieldControl(string field)
        {
            var form = _formDriver.GetForm();
            return form.FindElement(By.Id(field));
        }

    }
}
