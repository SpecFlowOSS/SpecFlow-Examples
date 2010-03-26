using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    public class ShoppingCart
    {
        List<LineItem> _lineItems = new List<LineItem>();

        public decimal Price 
        {
            get { return _lineItems.Sum(li => li.Price); }
        }

        public int Count
        {
            get { return _lineItems.Count; }
        }

        public IEnumerable<LineItem> LineItems
        {
            get { return _lineItems; }
        }

        public void AddLineItem(LineItem lineItem)
        {
            _lineItems.Add(lineItem);
        }

        public void RemoveLineItem (int bookId)
        {
            _lineItems.Remove(_lineItems.Where(li => li.Book.Id == bookId).FirstOrDefault());
        }
    }
}
