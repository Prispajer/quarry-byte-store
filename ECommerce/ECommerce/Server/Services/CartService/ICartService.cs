﻿using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Cart;

namespace ECommerce.Server.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartProductResponse>>> GetCartProducts(List<CartItem> cartItems);
    }
}
