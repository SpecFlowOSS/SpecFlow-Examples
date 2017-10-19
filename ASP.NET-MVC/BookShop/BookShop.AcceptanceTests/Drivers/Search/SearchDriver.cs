using BookShop.Controllers;

namespace BookShop.AcceptanceTests.Drivers.Search
{
    public class SearchDriver
    {
        private readonly SearchResultState _state;

        public SearchDriver(SearchResultState state)
        {
            this._state = state;
        }

        public void Search(string term)
        {
            var controller = new CatalogController();
            this._state.ActionResult = controller.Search(term);
        }
    }
}
