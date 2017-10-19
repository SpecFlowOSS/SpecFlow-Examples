using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BookShop.Models
{
    public class ShoppingCart
    {
        private readonly List<OrderLine> _orderLines = new List<OrderLine>();

        [DisplayName("Total Price")]
        public decimal Price => this._orderLines.Sum(li => li.Price);

        public int Count => this._orderLines.Sum(li => li.Quantity);

        public IEnumerable<OrderLine> Lines => this._orderLines;

        public void AddLineItem(OrderLine lineItem)
        {
            this._orderLines.Add(lineItem);
        }

        public void RemoveLineItem (int bookId)
        {
            this._orderLines.Remove(this._orderLines.FirstOrDefault(li => li.Book.Id == bookId));
        }
    }
}
