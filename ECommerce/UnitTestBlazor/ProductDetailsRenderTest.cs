using Bunit;
using Moq;
using ECommerce.Client.Services.ProductService;
using ECommerce.Shared;
using ECommerce.Client.Pages;
using ECommerce.Client.Services.CartService;
using Microsoft.Extensions.DependencyInjection;


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
                       <div class=""media"" >
                               <div class=""media-img-wrapper mr-2"" >
                               <img class=""media-img"" src=""{product.ImageUrl}"" alt=""{product.Title}"" >
                               </div>
                        <div class=""media-body"" >
                          <h2 class=""mb-0"" >{product.Title}</h2>
                          <p >{product.Description}</p>
                          <h4 class=""price"" ></h4>
                          <button class=""btn btn-primary""  >
                             <i class=""oi oi-cart"" ></i>&nbsp;&nbsp;&nbsp;Add to Cart
                          </button>
                         </div>
                       </div>";
            cut.MarkupMatches(expectedMarkup);     
        
        
        }
    }
}
