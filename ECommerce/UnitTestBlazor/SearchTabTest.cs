using Bunit;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Moq;
using ECommerce.Client.Services.ProductService;
using ECommerce.Client.Shared;
using Microsoft.Extensions.DependencyInjection;


namespace UnitTestBlazor
{
    public class SearchTabTest
    {

        [Fact]
        public async Task HandleSearchShouldFetchSuggestions()
        {
            
            var productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(p => p.GetProductSearchSuggestions(It.IsAny<string>()))
                .ReturnsAsync(new List<string> { "suggestion1", "suggestion2" });

            using var ctx = new TestContext();
            ctx.Services.AddSingleton(productServiceMock.Object);

            var searchComponent = ctx.RenderComponent<Search>();

            var inputElement = searchComponent.Find("input");
            await inputElement.TriggerEventAsync("oninput", new ChangeEventArgs { Value = "test" });

            
            await inputElement.TriggerEventAsync("onkeyup", new KeyboardEventArgs { Key = "A" });

            
            searchComponent.WaitForState(() => searchComponent.Find("datalist").ChildElementCount == 2);
        }
    }
}
