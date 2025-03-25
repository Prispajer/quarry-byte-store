using ECommerce.Client.Services.HttpService;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Product;

namespace ECommerce.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpService _httpService;

        public CategoryService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task GetCategories()
        {
            var response = await _httpService.SendRequestAsync<List<Category>>(HttpMethod.Get, "api/category");
            if (response.Data != null)
                Categories = response.Data;
        }
    }
}
