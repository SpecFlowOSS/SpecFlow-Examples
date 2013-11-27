using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BookShop.Models;

namespace BookShop.AcceptanceTests.Common
{
    public class BookAssertions
    {

        public static void FoundBooksShouldMatchTitles(List<Book> foundBooks, IEnumerable<string> expectedTitles)
        {
            Assert.IsTrue(_matchWithTitles(foundBooks, expectedTitles),
                "The found books do not match the expected books. Books found: '{0}' ",
                String.Join<string>(",", foundBooks.Select(b => b.Title)));
        }

        public static void FoundBooksShouldMatchTitlesInOrder(List<Book> foundBooks, IEnumerable<string> expectedTitles)
        {
            Assert.IsTrue(_matchInOrderWithTitles(foundBooks, expectedTitles),
                "The found are not shown in the expected order. Books found: '{0}'",
                String.Join<String>(",", foundBooks.Select(b => b.Title)));
        }

        public static void HomeScreenShouldShow(List<Book> shownBooks, string expectedTitle)
        {
            Assert.IsTrue(_matchAnyWithTitle(shownBooks, expectedTitle), "The home screen does not show the expected book. Show books: '{0}'",
                String.Join<String>(",", shownBooks.Select(b => b.Title)));
        }

        public static void HomeScreenShouldShow(List<Book> shownBooks, IEnumerable<string> expectedTitles)
        {
            Assert.IsTrue(_matchWithTitles(shownBooks, expectedTitles),
                "The home screen does not show the list of expected books. Books shown: '{0}'",
                String.Join<string>(",", shownBooks.Select(b => b.Title)));

        }

        public static void HomeScreenShouldShowInOrder(List<Book> shownBooks, IEnumerable<string> expectedTitles)
        {
            Assert.IsTrue(_matchInOrderWithTitles(shownBooks, expectedTitles),
                "The home screen does not show the list of expected books in the expected order. Books shown: '{0}'",
                String.Join<string>(",", shownBooks.Select(b => b.Title)));

        }


        private static bool _matchWithTitles(List<Book> books, IEnumerable<string> titles)
        {
            return titles.Count() == books.Count &&
                   titles.Except(books.Select(b => b.Title)).Count() == 0;
        }

        private static bool _matchInOrderWithTitles(List<Book> books, IEnumerable<string> titles)
        {
            return titles.SequenceEqual(books.Select(b => b.Title));
        }

        private static bool _matchAnyWithTitle(List<Book> books, string title)
        {
            return books.Any(b => b.Title == title);
        }

    }
}
