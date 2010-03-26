using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Selenium;
using TechTalk.SpecFlow;

namespace BookShop.Specs.Web
{
    [Binding]
    public class ShoppingCartSteps
    {
        private readonly ISelenium _selenium;
        private readonly CatalogSteps _catalogSteps;
        private readonly SeleniumSteps _seleniumSteps;

        public ShoppingCartSteps(SeleniumContext seleniumContext, CatalogSteps catalogSteps)
        {
            _selenium = seleniumContext.Selenium;
            _catalogSteps = catalogSteps;
            _seleniumSteps = new SeleniumSteps(seleniumContext);
        }

        [Given(@"I have a basket with: (.*)")]
        public void PrepareBasket(string bookIdList)
        {
            var bookIds = bookIdList.Split(',');
            foreach (string bookId in bookIds)
            {
                PlaceBookIntoShoppingCart(bookId);
            }
        }

        [When(@"I place (.*) into the basket")]
        public void PlaceBookIntoShoppingCart(string bookId)
        {
            string tmp = bookId;
            var referenceBookEntry = _catalogSteps.ReferenceBooks.Where(p => p.Key == tmp.Trim()).Single();
            var referenceBook = referenceBookEntry.Value;
            _seleniumSteps.GoToThePage("ShoppingCart");
            _selenium.WaitForPageToLoad("30000");
            _catalogSteps.PerformSimpleSearch(referenceBook.Title);
            _selenium.WaitForPageToLoad("30000");
            _seleniumSteps.ClickTheButton("Add");
        }

        [When(@"I enter the shop")]
        public void EnterTheStore()
        {
            _seleniumSteps.GoToThePage("ShoppingCart");
            _selenium.WaitForPageToLoad("30000");
        }

        [When(@"I put a book into my shopping cart")]
        public void WhenIPutABookIntoMyShoppingCart()
        {
            _seleniumSteps.GoToThePage("Catalog");
            _selenium.WaitForPageToLoad("30000");
            _catalogSteps.PerformSimpleSearch("Domain");
            _selenium.WaitForPageToLoad("30000");

            _seleniumSteps.ClickTheButton("Add");
        }

        [When(@"I remove the first line item of my shopping cart")]
        public void RemoveFirstLineItemFromShoppingCart()
        {
            _seleniumSteps.GoToThePage("ShoppingCart");
            _selenium.WaitForPageToLoad("30000");
            _seleniumSteps.ClickTheLink("Remove");
        }

        [When(@"I increase the quantity of the line item by '(\d*)'")]
        public void IncreaseQuantityOfLineItem(int quantity)
        {
            _seleniumSteps.GoToThePage("ShoppingCart");
            _selenium.WaitForPageToLoad("30000");
            _seleniumSteps.ClickTheLink("Edit");
            _selenium.WaitForPageToLoad("30000");
            int oldval =  Convert.ToInt32(_selenium.GetValue("css=input#Quantity"));
            int newval = oldval + 1;
            _selenium.Type("Quantity", newval.ToString());
            _selenium.Click("//input[@value='Save']");
        }

        [Then(@"my shopping cart should contain ([\d]+) items?")]
        public void ThenMyShoppingCartShouldContainLineItems(int count)
        {
            _seleniumSteps.GoToThePage("ShoppingCart");
            _selenium.WaitForPageToLoad("30000");
            Assert.AreEqual(count, _selenium.GetXpathCount("//div[@class='item']"), "Item count in shopping cart is not correct!");
        }

        [Then(@"my basket should contain exactly (\d+) (.*)")]
        public void ThenMyShoppingCartShouldContainBook(int count, string bookId)
        {
            var referenceBookEntry = _catalogSteps.ReferenceBooks.Where(p => p.Key == bookId.Trim()).Single();
            var referenceBook = referenceBookEntry.Value;

            _seleniumSteps.GoToThePage("ShoppingCart");
            _selenium.WaitForPageToLoad("30000");

            var itemTexts = new List<string>();
            var itemCount = _selenium.GetXpathCount("//div[@class='item']");
            for (int i = 1; i <= itemCount; i++)
            {
                var text = _selenium.GetText("//div[@class='item'][" + i + "]");
                itemTexts.Add(text);
            }
            Assert.IsTrue(itemTexts.Any(s => s.Contains(referenceBook.Title)));
        }

        [Then(@"the quantity should be '(\d)'")]
        public void CheckQuantityOfFirstLineItem(int count)
        {
            _seleniumSteps.GoToThePage("ShoppingCart");
            _selenium.WaitForPageToLoad("30000");
            Assert.AreEqual(count, Convert.ToInt32(_selenium.GetText("css=span#quantity")));
        }

        [Then(@"the total price should be set")]
        public void ThenTheTotalPriceShouldBeSet()
        {
            Assert.IsTrue(_selenium.IsTextPresent("regex:Price: \\d*,\\d{2}"));
        }       
        
        [Then(@"the resulting page should be '(.*)'")]
        public void CheckPage(string page)
        {
            Assert.IsTrue(Regex.IsMatch(_selenium.GetLocation(), "^[\\s\\S]*/" + page));
        }
    }
}
