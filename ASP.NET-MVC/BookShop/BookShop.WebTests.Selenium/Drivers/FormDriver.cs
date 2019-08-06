using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShop.WebTests.Selenium.Support;
using OpenQA.Selenium;

namespace BookShop.WebTests.Selenium.Drivers
{
    public class FormDriver
    {
        private readonly SeleniumController _seleniumController;

        public FormDriver(SeleniumController seleniumController)
        {
            _seleniumController = seleniumController;
        }

        public IWebElement GetForm()
        {
            return _seleniumController.WebDriver.FindElements(By.TagName("form")).First();
        }

        public void SubmitForm(string formId = null)
        {
            var form = formId == null ? GetForm()
                : _seleniumController.WebDriver.FindElements(By.Id(formId)).First();
            form.Submit();
            System.Threading.Thread.Sleep(100);
        }
    }
}
