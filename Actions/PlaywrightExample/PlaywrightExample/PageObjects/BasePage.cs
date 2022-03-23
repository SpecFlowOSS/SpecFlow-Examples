using System.Threading.Tasks;
using Microsoft.Playwright;
using SpecFlow.Actions.Playwright;

namespace PlaywrightExample.PageObjects
{
    public class BasePage
    {
        private readonly IPage _page;
        
        public BasePage(IPage page)
        {
            _page = page;
        }

        public IPage Page => _page;
    }
}