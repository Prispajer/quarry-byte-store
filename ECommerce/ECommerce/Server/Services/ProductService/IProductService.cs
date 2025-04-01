using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Product;

namespace ECommerce.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetAllAsync();
        Task<ServiceResponse<Product?>> GetByIdAsync(int productId);
        Task<ServiceResponse<List<Product>>> GetByCategoryAsync(string categoryUrl);
        Task<ServiceResponse<List<string>>> GetBySearchAsync(string searchText);
        Task<ServiceResponse<Product>> AddProductAsync(string title, string description, string imageUrl, int categoryId);
        Task<ServiceResponse<Product>> EditProductAsync(int id, string? title, string? description, string? imageUrl);
        Task<ServiceResponse<Product>> DeleteProductAsync(int id);
    }
}
