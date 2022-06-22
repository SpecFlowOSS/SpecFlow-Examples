using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Specs.Steps
{
    [Binding]
    public class ProductBindings
    {
        [Given(@"the price of (.*) is €(.*)")]
        public void GivenThePriceOfProductIsPrice(string product, float price)
        {
        }

        [Given(@"the customer has put (.*) piece of (.*) in the basket")]
        public void GivenTheCustomerHasPutPieceOfProductInTheBasket(int number, string product)
        {
        }

        [When(@"the basket price is calculated")]
        public void WhenTheBasketPriceIsCalculated()
        {
        }

        [Then(@"the basket price should be €(.*)")]
        public void ThenTheBasketPriceShouldBePrice(string price)
        {
        }

    }
}
