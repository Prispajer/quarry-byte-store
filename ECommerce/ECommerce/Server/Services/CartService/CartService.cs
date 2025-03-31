
using ECommerce.Server.Repositories.CartRepository;
using ECommerce.Shared.Models.Cart;
using ECommerce.Shared.Models;
using ECommerce.Shared.Dto.Cart;

namespace ECommerce.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<ServiceResponse<List<CartProductResponse>>> GetCartProductsAsync(List<GetCartProductsDto> cartItemsDto)
        {
            var result = new ServiceResponse<List<CartProductResponse>>()
            {
                Data = new List<CartProductResponse>()
            };

            foreach (var item in cartItemsDto)
            {
                var product = await _cartRepository.GetProductByIdAsync(item.ProductId);
                if (product == null)
                {
                    continue;
                }

                var productVariant = await _cartRepository.GetProductVariantAsync(item.ProductId, item.ProductTypeId);

                if (productVariant == null)
                {
                    continue;
                }

                var cartProduct = new CartProductResponse
                {
                    ProductId = product.Id,
                    Title = product.Title,
                    ImageUrl = product.ImageUrl,
                    Price = productVariant.Price,
                    ProductType = productVariant.ProductType.Name,
                    ProductTypeId = productVariant.ProductTypeId,
                    Quantity = item.Quantity
                };

                result.Data.Add(cartProduct);
            }

            return result;
        }
    }
}