using Bunit;
using Moq;
using ECommerce.Client.Services.ProductService;
using ECommerce.Shared;
using ECommerce.Client.Pages;
using ECommerce.Client.Services.CartService;
using Microsoft.Extensions.DependencyInjection;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Product;


namespace UnitTestBlazor
{
    public class ProductDetailsRenderTest : TestContext
    {
        [Fact]
        public void ProductDetailsComponentRendersCorrectly()
        {

            using var ctx = new TestContext();
            var mockProductService = new Mock<IProductService>();
            var mockCartService = new Mock<ICartService>();
            var product = new Product
            {
                Id = 1,
                Title = "Test Product",
                Description = "Test Description",
                ImageUrl = "https://test.com/test.jpg",
                Variants = new List<ProductVariant>()
            };
            mockProductService.Setup(service => service.GetProduct(It.IsAny<int>())).ReturnsAsync(new ServiceResponse<Product> { Data = product });

            ctx.Services.AddSingleton(mockProductService.Object);
            ctx.Services.AddSingleton(mockCartService.Object);


            var cut = ctx.RenderComponent<ProductDetails>(parameters => parameters
                .Add(p => p.Id, 1));


            var expectedMarkup = $@"
                            <div class=""specific-product-container"" >
                             <div class=""specific-product-image"" >
                            <img class=""specific-product-img"" src=""https://test.com/test.jpg"" alt=""Test Product"" >
                            </div>
                            <div class=""specific-product-details"" >
                            <div class=""specific-product-info"" >
                            <h2 >Test Product</h2>
                            <p >Test Description</p>
                            <div class=""specific-product-variant"" ></div>
                            </div>
                            <div class=""specific-product-button"" >
                            <button class=""specific-product-buy-button""  >
                            <span >Add to Cart</span>
                            </button>
                            </div>
                            </div>
                            </div>";
            cut.MarkupMatches(expectedMarkup);     
        
        
        }
    }
}
