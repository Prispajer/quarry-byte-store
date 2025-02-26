using Blazored.LocalStorage;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Cart;

namespace ECommerce.Client.Services.CartService
{

    public class CartService : ICartService
    {
        public event Action? OnChange;
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;

        public CartService(ILocalStorageService localStorage, HttpClient http)
        {
            _localStorage = localStorage;
            _http = http;
        }

        public async Task AddToCart(CartItem cartItem)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");

            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            var productExists = cart.Find(p => p.ProductId == cartItem.ProductId &&
                p.ProductTypeId == cartItem.ProductTypeId);

            if (productExists == null)
            {
                cart.Add(cartItem);
            }
            else
            {
                productExists.Quantity += cartItem.Quantity;
            }

            await _localStorage.SetItemAsync("cart", cart);
            OnChange?.Invoke();
        }

        public async Task<List<CartItem>> GetCartItems()
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");

            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            return cart;
        }

        public async Task<List<CartProductResponse>> GetCartProducts()
        {
            var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");

            var response = await _http.PostAsJsonAsync("api/cart/products", cartItems);

            var cartProducts =
                await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductResponse>>>();

            return cartProducts?.Data ?? new List<CartProductResponse>();
        }

        public async Task RemoveProductFromCart(int productId, int productTypeId)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                return;
            }

            var cartItem = cart.Find(x => x.ProductId == productId
                && x.ProductTypeId == productTypeId);
            if (cartItem != null)
            {
                cart.Remove(cartItem);
                await _localStorage.SetItemAsync("cart", cart);
                OnChange?.Invoke();
            }
        }

        public async Task UpdateQuantity(CartProductResponse product)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                return;
            }

            var cartItem = cart.Find(x => x.ProductId == product.ProductId
                && x.ProductTypeId == product.ProductTypeId);
            if (cartItem != null)
            {
                cartItem.Quantity = product.Quantity;
                await _localStorage.SetItemAsync("cart", cart);
            }
        }
    }
}

