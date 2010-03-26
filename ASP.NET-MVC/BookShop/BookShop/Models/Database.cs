using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    public class Database
    {
        private static BookShopEntities _db = new BookShopEntities();

        public static BookShopEntities Instance
        {
            get { return _db; }
        }
    }
}
