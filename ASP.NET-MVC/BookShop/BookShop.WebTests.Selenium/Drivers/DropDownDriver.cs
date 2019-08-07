using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShop.WebTests.Selenium.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BookShop.WebTests.Selenium.Drivers
{
    class DropDownDriver
    {
        private readonly SeleniumController _seleniumController;

        public DropDownDriver(SeleniumController seleniumController)
        {
            _seleniumController = seleniumController;
        }

        public  DropDown GetDropDown(string id)
        {
            return AsDropDown(_seleniumController.WebDriver.FindElement(By.Id(id)));
        }

        public DropDown AsDropDown(IWebElement e)
        {
            return new DropDown(e);
        }

        public class DropDown
        {
            private readonly IWebElement _dropDown;

            public DropDown(IWebElement dropDown)
            {
                this._dropDown = dropDown;

                if (dropDown.TagName != "select")
                    throw new ArgumentException("Invalid web element type");
            }

            public string SelectedValue
            {
                get
                {
                    var selectedOption = _dropDown.FindElements(By.TagName("option")).FirstOrDefault(e => e.Selected);

                    return selectedOption?.GetAttribute("value");

                }
                set
                {
                    new SelectElement(_dropDown).SelectByValue(value);
                }
            }
        }
    }
}
