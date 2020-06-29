using System.Text;
using BookShop.Mvc.Logic;
using BookShop.Mvc.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace BookShop.UnitTests
{
    public class ShoppingCartTests
    {
        [Fact]
        public void GetShoppingCart_EmptySession_EmptyShoppingCart()
        {
            var shoppingCartLogic = new ShoppingCartLogic(new Mock<IDatabaseContext>().Object);

            var sessionMock = new Mock<ISession>();
            sessionMock.Setup(m => m.TryGetValue(It.IsAny<string>(), out It.Ref<byte[]>.IsAny)).Returns(false);


            var shoppingCart = shoppingCartLogic.GetShoppingCart(sessionMock.Object);

            shoppingCart.Count.Should().Be(0);
        }

        [Fact]
        public void GetShoppingCart_StoredInSession()
        {
            var shoppingCartLogic = new ShoppingCartLogic(new Mock<IDatabaseContext>().Object);

            var sessionMock = new Mock<ISession>();
            sessionMock.Setup(m => m.TryGetValue(It.IsAny<string>(), out It.Ref<byte[]>.IsAny)).Returns(false);


            var shoppingCart = shoppingCartLogic.GetShoppingCart(sessionMock.Object);

            sessionMock.Verify(m => m.Set("CART", It.IsAny<byte[]>()), Times.Once);
        }

        delegate void GobbleCallback(string key, out byte[] data);

        [Fact]
        public void GetShoppingCart_AlreadySavedShoppingCart_IsReturned()
        {
            var cart = new ShoppingCart();
            cart.AddLineItem(new OrderLine(){BookId = 1, Quantity = 1, OrderId = 1, Book = new Book()
            {
                Id = 1,
                Price = 1m
            }});
            var serializedCart = JsonConvert.SerializeObject(cart);


            var shoppingCartLogic = new ShoppingCartLogic(new Mock<IDatabaseContext>().Object);

            var sessionMock = new Mock<ISession>();
            sessionMock.Setup(m => m.TryGetValue(It.IsAny<string>(), out It.Ref<byte[]>.IsAny))
                .Callback(new GobbleCallback((string key, out byte[] data) =>
                {
                    data = Encoding.UTF8.GetBytes(serializedCart);
                })).Returns(true);


            var shoppingCart = shoppingCartLogic.GetShoppingCart(sessionMock.Object);

            shoppingCart.Should().BeEquivalentTo(cart);
        }
    }
}
