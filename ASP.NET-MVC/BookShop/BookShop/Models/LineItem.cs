using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    public partial class LineItem
    {
        public decimal Price
        {
            get
            {
                return Quantity * Book.Price;
            }
        }
    }
}
