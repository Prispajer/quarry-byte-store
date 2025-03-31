using ECommerce.Shared.Models.Product;

namespace ECommerce.Server.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int productId);
        Task<List<Product>> GetByCategoryAsync(string categoryUrl);
        Task<List<Product>> SearchAsync(string searchText);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
