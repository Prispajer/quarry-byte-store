using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Product;

namespace ECommerce.Client.Services.CategoryService
{

    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public List<Category> Categories { get; set; } = new List<Category>();

        //Retrieves a list of product categories from the server
        public async Task GetCategories()
        {
            //Invoking an HTTP GET request to the API to retrieve the category and check whether the response is non-empty and contains data
            //assignment of downloaded categories 
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");
            if (response != null && response.Data != null)
                Categories = response.Data;
        }
    }
}
