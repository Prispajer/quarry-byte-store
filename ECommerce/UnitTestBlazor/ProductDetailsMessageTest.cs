using Bunit;
using ECommerce.Client.Pages;
using ECommerce.Client.Services.CartService;
using ECommerce.Client.Services.ProductService;
using ECommerce.Shared;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Product;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace UnitTestBlazor
{
    public class ProductDetailsMessageTest : TestContext
    {
        [Fact]
        public void ProductDetailsComponentRendersMessageWhenProductIsNull()
        {
            
            using var ctx = new TestContext();
            var mockProductService = new Mock<IProductService>();
            var mockCartService = new Mock<ICartService>();
            var message = "Product not found";
            mockProductService.Setup(service => service.GetProduct(It.IsAny<int>())).ReturnsAsync(new ServiceResponse<Product> { Success = false, Message = message });

            ctx.Services.AddSingleton(mockProductService.Object);
            ctx.Services.AddSingleton(mockCartService.Object);

            
            var cut = ctx.RenderComponent<ProductDetails>(parameters => parameters
                .Add(p => p.Id, 1));

            
            cut.MarkupMatches($"<span>{message}</span>");
        }
    }
}
