using System;
using System.Collections.Generic;
using System.Linq;
using BookShop.Mvc.Logic;
using BookShop.Mvc.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace BookShop.UnitTests
{
    public class BookLogicTests
    {
        [Fact]
        public void GetBookById_NotExisting_ThrowsException()
        {
            var books = new List<Book>().AsQueryable();

            var databaseContextMock = new Mock<IDatabaseContext>();
            var bookDbSetMock = new Mock<DbSet<Book>>();
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(books.Provider);
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(books.Expression);
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(books.ElementType);
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(books.GetEnumerator());

            databaseContextMock.SetupGet(m => m.Books).Returns(bookDbSetMock.Object);

            var bookLogic = new BookLogic(databaseContextMock.Object);

            Func<Book> getById = () => bookLogic.GetBookById(-1);

            getById.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void GetBookById_Existing_ReturnsBookWithId()
        {
            var books = new List<Book>()
            {
                new Book(){Id = 1},
                new Book(){Id = 2},
                new Book(){Id = 3}
            }.AsQueryable();

            var databaseContextMock = new Mock<IDatabaseContext>();
            var bookDbSetMock = new Mock<DbSet<Book>>();
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(books.Provider);
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(books.Expression);
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(books.ElementType);
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(books.GetEnumerator());

            databaseContextMock.SetupGet(m => m.Books).Returns(bookDbSetMock.Object);

            var bookLogic = new BookLogic(databaseContextMock.Object);

            var actualBook = bookLogic.GetBookById(2);

            actualBook.Id.Should().Be(2);
        }


        [Fact]
        public void FindCheapBooks_MoreBooksThanRequested_LimitedNumber()
        {
            var books = new List<Book>()
            {
                new Book(){Id = 1},
                new Book(){Id = 2},
                new Book(){Id = 3}
            }.AsQueryable();

            var databaseContextMock = new Mock<IDatabaseContext>();
            var bookDbSetMock = new Mock<DbSet<Book>>();
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(books.Provider);
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(books.Expression);
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(books.ElementType);
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(books.GetEnumerator());

            databaseContextMock.SetupGet(m => m.Books).Returns(bookDbSetMock.Object);

            var bookLogic = new BookLogic(databaseContextMock.Object);

            var actualCheapBooks = bookLogic.FindCheapBooks(2);

            actualCheapBooks.Length.Should().Be(2);
        }

        [Fact]
        public void FindCheapBooks_SortedByCheapestPrice()
        {
            var books = new List<Book>()
            {
                new Book(){Id = 1, Price = 1},
                new Book(){Id = 2, Price = 2},
                new Book(){Id = 3, Price = 3}
            }.AsQueryable();

            var databaseContextMock = new Mock<IDatabaseContext>();
            var bookDbSetMock = new Mock<DbSet<Book>>();
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(books.Provider);
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(books.Expression);
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(books.ElementType);
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(books.GetEnumerator());

            databaseContextMock.SetupGet(m => m.Books).Returns(bookDbSetMock.Object);

            var bookLogic = new BookLogic(databaseContextMock.Object);

            var actualCheapBooks = bookLogic.FindCheapBooks(3);

            actualCheapBooks[0].Id.Should().Be(1);
            actualCheapBooks[1].Id.Should().Be(2);
            actualCheapBooks[2].Id.Should().Be(3);
        }

        [Fact]
        public void FindCheapBooks_SamePrice_SortedByTitle()
        {
            var books = new List<Book>()
            {
                new Book(){Id = 1, Price = 2, Title = "1Book"},
                new Book(){Id = 2, Price = 2, Title = "2Book"},
                new Book(){Id = 3, Price = 3, Title = "3Book"}
            }.AsQueryable();

            var databaseContextMock = new Mock<IDatabaseContext>();
            var bookDbSetMock = new Mock<DbSet<Book>>();
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(books.Provider);
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(books.Expression);
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(books.ElementType);
            bookDbSetMock.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(books.GetEnumerator());

            databaseContextMock.SetupGet(m => m.Books).Returns(bookDbSetMock.Object);

            var bookLogic = new BookLogic(databaseContextMock.Object);

            var actualCheapBooks = bookLogic.FindCheapBooks(3);

            actualCheapBooks[0].Id.Should().Be(1);
            actualCheapBooks[1].Id.Should().Be(2);
            actualCheapBooks[2].Id.Should().Be(3);
        }
    }
}
