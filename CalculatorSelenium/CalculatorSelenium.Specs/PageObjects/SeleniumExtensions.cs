using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CalculatorSelenium.Specs.PageObjects
{
    public static class SeleniumExtensions
    {
        public const int DefaultWaitInSeconds = 5;

        public static string WaitUntilNonEmpty(this IWebDriver webDriver, Func<IWebDriver, string> func)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
            return wait.Until(driver =>
            {
                var result = func(driver);
                if (string.IsNullOrEmpty(result))
                    return null;

                return result;
            });

        }

        public static string GetValue(this IWebElement webElement)
        {
            return webElement.GetAttribute("value");
        }

        public static void SetText(this IWebElement webElement, string text)
        {
            webElement.Clear();
            webElement.SendKeys(text);
        }
    }
}
