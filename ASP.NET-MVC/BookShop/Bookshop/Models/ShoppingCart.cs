using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Bookshop.Models;

namespace BookShop.Models
{
    public class ShoppingCart
    {
        readonly List<OrderLine> orderLines = new List<OrderLine>();

        [DisplayName("Total Price")]
        public decimal Price 
        {
            get { return orderLines.Sum(li => li.Price); }
        }

        public int Count
        {
            get { return orderLines.Count; }
        }

        public IEnumerable<OrderLine> Lines
        {
            get { return orderLines; }
        }

        public void AddLineItem(OrderLine lineItem)
        {
            orderLines.Add(lineItem);
        }

        public void RemoveLineItem (int bookId)
        {
            orderLines.Remove(orderLines.Where(li => li.Book.Id == bookId).FirstOrDefault());
        }
    }
}
