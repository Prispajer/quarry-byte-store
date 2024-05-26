namespace ECommerce.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
        Task<ServiceResponse<Product>> GetProductAsync(int productId);

        Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl);

        Task<ServiceResponse<List<Product>>> SearchProducts(string searchText);
        Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);

        Task<ServiceResponse<Product>> AddProductAsync(string title, string description, string imageUrl, int categoryId);
        Task<ServiceResponse<Product>> EditProductAsync(int id, string? title, string? description, string? imageUrl);
        Task<ServiceResponse<Product>> DeleteProductAsync(int id);
    }
}
