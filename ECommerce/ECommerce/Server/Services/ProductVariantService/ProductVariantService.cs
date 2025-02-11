using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Product;

namespace ECommerce.Server.Services.ProductVariantService
{
    public class ProductVariantService: IProductVariantService
    {
        private readonly DataContext _context;

        public ProductVariantService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<ProductVariant>>> GetProductVariantsForProductAsync(int productId)
        {
            var product = await GetProduct(productId);
            if (product == null)
            {
                return new ServiceResponse<List<ProductVariant>>
                {
                    Data = null,
                    Success = false,
                    Message = "No Product found for given productId"
                };
            }

            var variants = await _context.ProductVariants.Where(p => p.ProductId == productId).ToListAsync();
            return new ServiceResponse<List<ProductVariant>>
            {
                Data = variants,
                Success = true
            };
        }

        public async Task<ServiceResponse<ProductVariant>> AddProductVariantAsync(int productId, int productTypeId, decimal price, decimal originalPrice)
        {
            var product = await GetProduct(productId);
            if (product == null)
            {
                return new ServiceResponse<ProductVariant>
                {
                    Data = null,
                    Success = false,
                    Message = "No Product found for given productId"
                };
            }

            var productType = await GetProductType(productTypeId);
            if (productType == null)
            {
                return new ServiceResponse<ProductVariant>
                {
                    Data = null,
                    Success = false,
                    Message = "No ProductType found for given productTypeId"
                };
            }

            var existingVariant = await GetProductVariant(productId, productTypeId);
            if (existingVariant != null)
            {
                return new ServiceResponse<ProductVariant>
                {
                    Data = null,
                    Success = false,
                    Message = "ProductVariant already exists for given productId and productTypeId"
                };
            }

            var variant = new ProductVariant()
            {
                Product = product,
                ProductId = productId,
                ProductType = productType,
                ProductTypeId = productTypeId,
                Price = price,
                OriginalPrice = originalPrice
            };

            _context.ProductVariants.Add(variant);
            _context.SaveChanges();

            return new ServiceResponse<ProductVariant>
            {
                Data = variant,
                Success = true,
                Message = "ProductVariant added successfully"
            };
        }

        public async Task<ServiceResponse<ProductVariant>> EditProductVariantAsync(int productId, int productTypeId, decimal price, decimal originalPrice)
        {
            var product = await GetProduct(productId);
            if (product == null)
            {
                return new ServiceResponse<ProductVariant>
                {
                    Data = null,
                    Success = false,
                    Message = "No Product found for given productId"
                };
            }

            var productType = await GetProductType(productTypeId);
            if (productType == null)
            {
                return new ServiceResponse<ProductVariant>
                {
                    Data = null,
                    Success = false,
                    Message = "No ProductType found for given productTypeId"
                };
            }

            var variant = await GetProductVariant(productId, productTypeId);
            if (variant == null)
            {
                return new ServiceResponse<ProductVariant>
                {
                    Data = null,
                    Success = false,
                    Message = "No ProductVariant found for given productId and productTypeId"
                };
            }

            _context.ProductVariants.Update(variant);
            variant.Price = price;
            variant.OriginalPrice = originalPrice;
            _context.SaveChanges();

            return new ServiceResponse<ProductVariant>
            {
                Data = variant,
                Success = true,
                Message = "ProductVariant updated successfully"
            };
        }

        public async Task<ServiceResponse<ProductVariant>> DeleteProductVariantAsync(int productId, int productTypeId)
        {
            var variant = await GetProductVariant(productId, productTypeId);
            if (variant == null)
            {
                return new ServiceResponse<ProductVariant>
                {
                    Data = null,
                    Success = false,
                    Message = "No ProductVariant found for given productId and productTypeId"
                };
            }
            _context.ProductVariants.Remove(variant);
            _context.SaveChanges();

            return new ServiceResponse<ProductVariant>
            {
                Data = variant,
                Success = true,
                Message = "ProductVariant removed successfully"
            };
        }

        private async Task<Product?> GetProduct(int productId)
        {
            return await _context.Products.Where(p => p.Id == productId).SingleOrDefaultAsync();
        }

        private async Task<ProductType?> GetProductType(int productTypeId)
        {
            return await _context.ProductTypes.Where(p => p.Id == productTypeId).SingleOrDefaultAsync();
        }

        private async Task<ProductVariant?> GetProductVariant(int productId, int productTypeId)
        {
            return await _context.ProductVariants.Where(p => p.ProductId == productId && p.ProductTypeId == productTypeId).SingleOrDefaultAsync();
        }
    }
}
