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

        public ProductVariantController(IProductVariantService productVariantService)
        {
            _productVariantService = productVariantService;
        }

        [HttpPost("add")]
        [Authorize(Policy = "IsAnAdmin")]
        public async Task<ActionResult<ServiceResponse<Product>>> AddProductVariant(AddProductVariantDto addProductVariantDto)
        {
            var result = await _productVariantService.AddProductVariantAsync(addProductVariantDto.ProductId, addProductVariantDto.ProductTypeId, addProductVariantDto.Price, addProductVariantDto.OriginalPrice);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPatch("edit")]
        [Authorize(Policy = "IsAnAdmin")]
        public async Task<ActionResult<ServiceResponse<Product>>> EditProductVariant(EditProductVariantDto editProductVariantDto)
        {
            var result = await _productVariantService.EditProductVariantAsync(editProductVariantDto.ProductId, editProductVariantDto.ProductTypeId, editProductVariantDto.Price, editProductVariantDto.OriginalPrice);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        [Authorize(Policy = "IsAnAdmin")]
        public async Task<ActionResult<ServiceResponse<Product>>> DeleteProductVariant(DeleteProductVariantDto deleteProductVariantDto)
        {
            var result = await _productVariantService.DeleteProductVariantAsync(deleteProductVariantDto.ProductId, deleteProductVariantDto.ProductTypeId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}