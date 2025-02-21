using ECommerce.Shared.Models.Product;

namespace ECommerce.Server.Repositories.CartRepository
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _context;

        public CartRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }

        public async Task<ProductVariant?> GetProductVariantAsync(int productId, int productTypeId)
        {
            return await _context.ProductVariants
                .Include(v => v.ProductType)
                .FirstOrDefaultAsync(v => v.ProductId == productId && v.ProductTypeId == productTypeId);
        }
    }
}
