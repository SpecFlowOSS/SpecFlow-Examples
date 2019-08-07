using System;
using System.Collections.Generic;
using System.Text;
using BookShop.WebTests.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace BookShop.WebTests.Selenium.Drivers
{
    public class TextBoxDriver
    {
        private readonly SeleniumController _seleniumController;
        private readonly FieldDriver _fieldDriver;

        public TextBoxDriver(SeleniumController seleniumController, FieldDriver fieldDriver)
        {
            _seleniumController = seleniumController;
            _fieldDriver = fieldDriver;
        }

        public string GetTextBoxValue(string field)
        {
            var control = _fieldDriver.GetFieldControl(field);

            return control.GetAttribute("value");
        }

        public void SetTextBoxValue(string field, string value)
        {
            var control = _fieldDriver.GetFieldControl(field);
            var wait = new WebDriverWait(_seleniumController.WebDriver, SeleniumController.DefaultTimeout);
            if (!string.IsNullOrEmpty(control.GetAttribute("value")))
            {
                control.Clear();
                wait.Until(_ => string.IsNullOrEmpty(control.GetAttribute("value")));
            }

            control.SendKeys(value);
            //            wait.Until( _ => control.Value == value);
            System.Threading.Thread.Sleep(100);
        }
    }
}
