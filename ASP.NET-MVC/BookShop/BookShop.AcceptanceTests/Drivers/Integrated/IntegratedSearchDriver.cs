using BookShop.Mvc.Controllers;
using BookShop.Mvc.Logic;

namespace BookShop.AcceptanceTests.Drivers.Integrated
{
    public class IntegratedSearchDriver : ISearchDriver
    {
        private readonly BookLogic _bookLogic;
        private readonly SearchResultState _state;

        public IntegratedSearchDriver(SearchResultState state, BookLogic bookLogic)
        {
            _state = state;
            _bookLogic = bookLogic;
        }

        public void Search(string term)
        {
            var controller = new CatalogController(_bookLogic);
            _state.ActionResult = controller.Search(term);
        }
    }
}
