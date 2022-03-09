using Microsoft.Playwright;
using SpecFlow.Actions.Playwright;
using System.Threading.Tasks;

namespace Example.PageObjects
{
    public class BasePage
    {
        public readonly Task<IBrowserContext> _browserContext;
        private readonly Task<ITracing> _tracing;
        public readonly Task<IPage> _page;

        public Task<ITracing> Tracing => _tracing;
        
        public BasePage(BrowserDriver browserDriver)
        {
            _browserContext = CreateBrowserContextAsync(browserDriver.Current);
            _tracing = _browserContext.ContinueWith(t => t.Result.Tracing);
            _page = CreatePageAsync(_browserContext);
            
        }

        private async Task<IBrowserContext> CreateBrowserContextAsync(Task<IBrowser> browser)
        {
            return await (await browser).NewContextAsync();
        }

        private async Task<IPage> CreatePageAsync(Task<IBrowserContext> browserContext)
        {
            return await (await browserContext).NewPageAsync();
        }

    }
}