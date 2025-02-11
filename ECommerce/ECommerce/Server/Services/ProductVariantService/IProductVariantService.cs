using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Product;

namespace ECommerce.Server.Services.ProductVariantService
{
    public interface IProductVariantService
    {
        Task<ServiceResponse<List<ProductVariant>>> GetProductVariantsForProductAsync(int productId);
        Task<ServiceResponse<ProductVariant>> AddProductVariantAsync(int productId, int productTypeId, decimal price, decimal originalPrice);
        Task<ServiceResponse<ProductVariant>> EditProductVariantAsync(int productId, int productTypeId, decimal price, decimal originalPrice);
        Task<ServiceResponse<ProductVariant>> DeleteProductVariantAsync(int productId, int productTypeId);
    }
}