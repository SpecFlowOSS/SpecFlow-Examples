using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace BookShop.AcceptanceTests.Drivers.Selenium.PageObjects
{
    class SearchResultEntry
    {
        private readonly IWebElement _row;

        public SearchResultEntry(IWebElement row)
        {
            _row = row;
        }

        public string Title
        {
            get
            {
                var rowText = _row.Text;
                

                var webElement = _row.FindElement(By.ClassName("title"));
                var linkElement = webElement.FindElement(By.TagName("a"));
                return linkElement.Text;
            }
        }

        public string Author => _row.FindElement(By.ClassName("#author")).Text;

        public string Price => _row.FindElement(By.ClassName("#price")).Text;

        public IWebElement AddToCartButton => _row.FindElement(By.LinkText("Add to cart"));


        public void AddToCart()
        {
            AddToCartButton.Click();

        }
    }
}
