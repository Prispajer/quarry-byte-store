using ECommerce.Shared.Models.Cart;

namespace ECommerce.Client.Services.CartService
{
    public interface ICartService
    {
        Task AddToCart(CartItem cartItem);
        Task<List<CartItem>> GetCartItems();
        Task<List<CartProductResponse>> GetCartProducts();
        Task RemoveProductFromCart(int productId, int productTypeId);
        Task UpdateQuantity(CartProductResponse product);
    }
}
