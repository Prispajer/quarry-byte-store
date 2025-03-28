﻿using ECommerce.Shared.Dto.Cart;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Cart;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ILogger<CartController> _logger;

        public CartController(ICartService cartService, ILogger<CartController> logger)
        {
            _cartService = cartService;
            _logger = logger;
        }

        [HttpPost("products")]
        public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> GetCartProducts(List<GetCartProductsDto> cartItemsDto)
        {
            try
            {
                var cartItems = cartItemsDto.Select(dto => new CartItem
                {
                    ProductId = dto.ProductId,
                    ProductTypeId = dto.ProductTypeId,
                    Quantity = dto.Quantity
                }).ToList();

                var result = await _cartService.GetCartProducts(cartItemsDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Cart retrieval error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}
