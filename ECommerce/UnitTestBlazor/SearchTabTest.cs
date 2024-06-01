using Bunit;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Moq;
using ECommerce.Client.Services.ProductService;
using ECommerce.Client.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Exchange.WebServices.Data;
using ECommerce.Client.Services.ModalService;

namespace UnitTestBlazor
{
    public class SearchTabTest : TestContext
    {

        
    [Fact]
        public void SearchInput_OnKeyUp_CallsHandleSearch()
        {
            var mockProductService = new Mock<IProductService>();
            var mockModalService = new Mock<IModalService>();
            var mockNavigationManager = new Mock<NavigationManager>();

            Services.AddSingleton(mockProductService.Object);
            Services.AddSingleton(mockModalService.Object);
            Services.AddSingleton(mockNavigationManager.Object);

            var cut = RenderComponent<SearchInput>();

            // Act
            cut.Find("input.search-input").Change("test");
            cut.Find("input.search-input").KeyUp(new KeyboardEventArgs { Key = "a" });

            // Assert
            mockProductService.Verify(s => s.GetProductSearchSuggestions(It.IsAny<string>()), Times.Once());
        }

    }
}
