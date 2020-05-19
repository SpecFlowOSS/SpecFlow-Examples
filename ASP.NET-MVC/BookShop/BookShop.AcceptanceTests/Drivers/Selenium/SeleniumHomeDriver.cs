using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Drivers.Selenium
{
    class SeleniumHomeDriver : IHomeDriver
    {
        public void Navigate()
        {
            throw new System.NotImplementedException();
        }

        public void ShowsBook(string expectedTitle)
        {
            throw new System.NotImplementedException();
        }

        public void ShowsBooks(string expectedTitles)
        {
            throw new System.NotImplementedException();
        }

        public void ShowsBooks(Table expectedBooks)
        {
            throw new System.NotImplementedException();
        }

        public void ShowsBooks(IEnumerable<string> expectedTitles)
        {
            throw new System.NotImplementedException();
        }
    }
}