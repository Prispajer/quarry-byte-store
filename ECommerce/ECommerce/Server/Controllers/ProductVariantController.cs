using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Product;
using ECommerce.Shared.Dto.ProductVariant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Server.Services.ProductVariantService;

namespace ECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantController : ControllerBase
    {
        private readonly IProductVariantService _productVariantService;
        private readonly ILogger<ProductVariantController> _logger;

        public ProductVariantController(IProductVariantService productVariantService, ILogger<ProductVariantController> logger)
        {
            _productVariantService = productVariantService;
            _logger = logger;
        }

        [HttpPost("add")]
        [Authorize(Policy = "IsAnAdmin")]
        public async Task<ActionResult<ServiceResponse<Product>>> AddProductVariant(AddProductVariantDto addProductVariantDto)
        {
            try
            {
                var result = await _productVariantService.AddProductVariantAsync(addProductVariantDto.ProductId, addProductVariantDto.ProductTypeId, addProductVariantDto.Price, addProductVariantDto.OriginalPrice);
                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Add product variant error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPatch("edit")]
        [Authorize(Policy = "IsAnAdmin")]
        public async Task<ActionResult<ServiceResponse<Product>>> EditProductVariant(EditProductVariantDto editProductVariantDto)
        {
            try
            {
                var result = await _productVariantService.EditProductVariantAsync(editProductVariantDto.ProductId, editProductVariantDto.ProductTypeId, editProductVariantDto.Price, editProductVariantDto.OriginalPrice);
                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Edit product variant error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }

        }

        [HttpDelete("delete")]
        [Authorize(Policy = "IsAnAdmin")]
        public async Task<ActionResult<ServiceResponse<Product>>> DeleteProductVariant(DeleteProductVariantDto deleteProductVariantDto)
        {
            try
            {
                var result = await _productVariantService.DeleteProductVariantAsync(deleteProductVariantDto.ProductId, deleteProductVariantDto.ProductTypeId);
                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Delete product variant error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }

        }
    }
}