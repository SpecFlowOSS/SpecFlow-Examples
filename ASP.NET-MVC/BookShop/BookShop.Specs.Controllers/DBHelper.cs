using BookShop.Models;

namespace BookShop.Specs.Controllers
{
    public class DBHelper
    {
        private static BookShopEntities _db = Database.Instance;

        static public void Clean()
        {
            foreach (var lineItem in _db.LineItem)
            {
                _db.DeleteObject(lineItem);
            }    
            foreach (var book in _db.BookSet)
            {
                _db.DeleteObject(book);
            }
            foreach (var order in _db.OrderSet)
            {
                _db.DeleteObject(order);
            }
            _db.SaveChanges();
        }
    }
}