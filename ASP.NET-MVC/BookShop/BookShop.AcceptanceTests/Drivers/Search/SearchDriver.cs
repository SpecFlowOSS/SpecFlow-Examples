using BookShop.Mvc.Controllers;
using BookShop.Mvc.Models;

namespace BookShop.AcceptanceTests.Drivers.Search
{
    public class SearchDriver
    {
        private readonly IDatabaseContext _databaseContext;
        private readonly SearchResultState _state;

        public SearchDriver(SearchResultState state, InMemoryDbContext databaseContext)
        {
            _state = state;
            _databaseContext = databaseContext;
        }

        public void Search(string term)
        {
            var controller = new CatalogController(_databaseContext);
            _state.ActionResult = controller.Search(term);
        }
    }
}
