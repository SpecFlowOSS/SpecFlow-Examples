using System.IO;
using System.Linq;
using BookShop.Models;
using NUnit.Framework;
using Selenium;
using TechTalk.SpecFlow;

namespace BookShop.Specs.Web
{
    [Binding]
    public class OrderSubmissionSteps
    {
        private readonly ISelenium _selenium;
        private readonly SeleniumSteps _seleniumSteps;
        private Order _order;

        public OrderSubmissionSteps(SeleniumContext seleniumContext)
        {
            _selenium = seleniumContext.Selenium;
            _seleniumSteps = new SeleniumSteps(seleniumContext);
        }

        [When(@"I check out the cart")]
        public void WhenICheckOutTheCart()
        {
            _seleniumSteps.GoToThePage("ShoppingCart");
            _selenium.WaitForPageToLoad("30000");
            _seleniumSteps.ClickTheButton("Submit");
        }

        [Then(@"an order should be created")]
        public void ThenAnOrderShouldBeCreated()
        {
            BookShopEntities _db = new BookShopEntities();
            int orderCount = _db.OrderSet.Count();
//            Assert.AreEqual(1,orderCount);

            _order = _db.OrderSet.First();
            Assert.IsNotNull(_order);
        }

        [Then(@"the order should have (\d*) line item")]
        public void ThenTheOrderShouldHave1LineItem(int count)
        {
            _order.LineItems.Load();
            Assert.AreEqual(count, _order.LineItems.Count);
        }
        [Then(@"the price of the order should be set")]
        public void ThenThePriceOfTheOrderShouldBeSet()
        {
            Assert.IsTrue(_order.Price > 0);
        }
        [Then(@"the order status should be '(.*)'")]
        public void ThenTheOrderStatusShouldBe(string status)
        {
            var directory = Directory.GetCurrentDirectory();
            Assert.AreEqual(status, _order.Status);
        }
    }
}
