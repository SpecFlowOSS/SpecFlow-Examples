using System;
using System.Configuration;
using System.IO;
using Selenium;

namespace BookShop.Specs.Web
{
    public class SeleniumContext
    {
        private ISelenium _selenium;

        public SeleniumContext()
        {
            var dataDirectory = ConfigurationManager.AppSettings["DataDirectory"];
            var absoluteDataDirectory = Path.GetFullPath(dataDirectory);
            var appUrl = ConfigurationManager.AppSettings["AppUrl"];

            AppDomain.CurrentDomain.SetData("DataDirectory", absoluteDataDirectory);
            _selenium = new DefaultSelenium("localhost", 4444, "*chrome", appUrl);
        }

        public ISelenium Selenium
        {
            get {
                return _selenium;
            }
        }
    }
}