using System.Collections.Generic;
using BookShop.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookShop.WebTests.Selenium.Support
{
    public class ReferenceBookList : Dictionary<string, Book>
    {
        public Book GetById(string bookId)
        {
            var result = this[bookId.Trim()];
            Assert.IsNotNull(result, "no reference book with id: " + bookId);
            return result;
        }
    }
}
