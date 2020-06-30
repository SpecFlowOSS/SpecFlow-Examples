using BookShop.AcceptanceTests.Drivers.Selenium.PageObjects;

namespace BookShop.AcceptanceTests.Drivers.Selenium
{
    class SeleniumSearchDriver : ISearchDriver
    {
        private readonly BrowserDriver _browserDriver;
        private readonly WebServerDriver _webServerDriver;

        public SeleniumSearchDriver(BrowserDriver browserDriver, WebServerDriver webServerDriver)
        {
            _browserDriver = browserDriver;
            _webServerDriver = webServerDriver;
        }

        public void Search(string term)
        {
            _browserDriver.Current.Navigate().GoToUrl(_webServerDriver.Hostname);

            var homePageObject = new HomePageObject(_browserDriver.Current);

            homePageObject.Search(term);

        }
    }
}