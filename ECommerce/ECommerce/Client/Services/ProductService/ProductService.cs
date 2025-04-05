using ECommerce.Client.Services.HttpService;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Product;
using static System.Net.WebRequestMethods;

namespace ECommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        private readonly IHttpService _httpService;
        public event Action? ProductsChanged;

        public ProductService(IHttpService httpService, HttpClient http)
        {
            _http = http;

            _httpService = httpService;
        }

        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading products...";

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            return await _httpService.SendRequestAsync<Product>(HttpMethod.Get, $"api/product/{productId}");
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = await _httpService.SendRequestAsync<List<Product>>(
                HttpMethod.Get,
                categoryUrl == null ? "api/product" : $"api/product/category/{categoryUrl}"
            );

            if (result != null && result.Data != null)
                Products = result.Data;

            ProductsChanged?.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _httpService.SendRequestAsync<List<string>>(HttpMethod.Get, $"api/product/searchsuggestions/{searchText}");

            if (result.Data != null)
            {
                return result.Data;
            }

            return new List<string>();
        }

        public async Task SearchProducts(string searchText)
        {
            var result = await _http
                 .GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/search/{searchText}");
            if (result != null && result.Data != null)
                Products = result.Data;
            if (Products.Count == 0) Message = "Product is not available";
            ProductsChanged?.Invoke();
        }


    }
}
