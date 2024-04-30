using Blazored.LocalStorage;
using Bunit;
using ECommerce.Client.Services.CartService;
using ECommerce.Client.Shared;
using ECommerce.Shared;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestBlazor
{
    public class CartProductsCountTest
    {
       
        
            [Fact]
            public void CartCounter_DisplaysCorrectItemCount()
            {
                var localStorageMock = new Mock<ISyncLocalStorageService>();
                var cartServiceMock = new Mock<ICartService>();
                var itemsInCart = new List<CartItem>
            {
                new CartItem { ProductId = 1},
                new CartItem { ProductId = 2},
                new CartItem { ProductId = 5}

            };
                localStorageMock.Setup(mock => mock.GetItem<List<CartItem>>("cart")).Returns(itemsInCart);

                var services = new ServiceCollection();
                services.AddSingleton<ISyncLocalStorageService>(localStorageMock.Object);
                services.AddSingleton<ICartService>(cartServiceMock.Object);

                using var ctx = new TestContext();
                ctx.Services.AddSingleton(serviceProvider => services.BuildServiceProvider());
                ctx.Services.AddSingleton<ISyncLocalStorageService>(localStorageMock.Object);
                ctx.Services.AddSingleton<ICartService>(cartServiceMock.Object);

                var cut = ctx.RenderComponent<CartCounter>();




                var badgeElement = cut.Find(".badge");
                Assert.Equal("3", badgeElement.TextContent);
            }
    }
}

