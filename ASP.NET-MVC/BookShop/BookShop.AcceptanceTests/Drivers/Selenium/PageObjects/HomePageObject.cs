using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BookShop.AcceptanceTests.Drivers.Selenium.PageObjects
{
    class HomePageObject
    {
        private readonly IWebDriver _webDriver;

        public HomePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public IWebElement SearchTerm => _webDriver.FindElement(By.Id("searchTerm"));

        public IWebElement SearchButton => _webDriver.FindElement(By.Id("searchForm"));

        public void Search(string term)
        {
            SearchTerm.Clear();
            SearchTerm.SendKeys(term);

            SearchButton.Submit();

            RetryHelper.WaitFor(() => _webDriver.Url.EndsWith("Catalog/Search"));


        }
    }
}
