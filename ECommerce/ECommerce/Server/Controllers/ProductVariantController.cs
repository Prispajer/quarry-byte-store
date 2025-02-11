using ECommerce.Server.Services.ProductVariantService;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantController: ControllerBase
    {
        private readonly IProductVariantService _productVariantService;

        public ProductVariantController(IProductVariantService productVariantService)
        {
            _productVariantService = productVariantService;
        }

        [HttpPost("add")]
        [Authorize(Policy = "IsAnAdmin")]
        public async Task<ActionResult<ServiceResponse<ProductVariant>>> AddProductVariant(int productId, int productTypeId, decimal price, decimal originalPrice)
        {
            var result = await _productVariantService.AddProductVariantAsync(productId, productTypeId, price, originalPrice);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPatch("edit")]
        [Authorize(Policy = "IsAnAdmin")]
        public async Task<ActionResult<ServiceResponse<ProductVariant>>> EditProductVariant(int productId, int productTypeId, decimal price, decimal originalPrice)
        {
            var result = await _productVariantService.EditProductVariantAsync(productId, productTypeId, price, originalPrice);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        [Authorize(Policy = "IsAnAdmin")]
        public async Task<ActionResult<ServiceResponse<ProductVariant>>> DeleteProductVariant(int productId, int productTypeId)
        {
            var result = await _productVariantService.DeleteProductVariantAsync(productId, productTypeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
