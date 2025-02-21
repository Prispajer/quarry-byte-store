using ECommerce.Shared.Models.Product;

namespace ECommerce.Server.Repositories.CartRepository
{
    public interface ICartRepository
    {
        Task<Product?> GetProductByIdAsync(int productId);
        Task<ProductVariant?> GetProductVariantAsync(int productId, int productTypeId);
    }
}
