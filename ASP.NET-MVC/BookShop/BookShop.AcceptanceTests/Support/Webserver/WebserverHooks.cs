using System.Threading.Tasks;
using BookShop.AcceptanceTests.Drivers.Selenium;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Support.Webserver
{
    [Binding]
    public class WebserverHooks
    {
        private readonly ConfigurationDriver _configurationDriver;
        private readonly WebServerDriver _webServerDriver;

        public WebserverHooks(ConfigurationDriver configurationDriver, WebServerDriver webServerDriver)
        {
            _configurationDriver = configurationDriver;
            _webServerDriver = webServerDriver;
        }


        [BeforeScenario(Order = 1000)]
        public void StartWebserver()
        {
            if (_configurationDriver.Mode != "Integrated")
            {
                _webServerDriver.Start();
            }
        }

        [AfterScenario()]
        public async Task StopWebserver()
        {
            await _webServerDriver.Stop();
        }
    }
}