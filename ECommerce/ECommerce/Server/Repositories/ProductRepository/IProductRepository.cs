using ECommerce.Shared.Models.Product;

namespace ECommerce.Server.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<Product?> GetProductByIdAsync(int productId);
        Task<List<Product>> GetProductsAsync();
        Task<List<Product>> GetProductsByCategoryAsync(string categoryUrl);
        Task<List<Product>> SearchProductsAsync(string searchText);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);
    }
}
