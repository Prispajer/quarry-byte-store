using ECommerce.Server.Services.ProductTypeService;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;
        private readonly ILogger<ProductTypeController> _logger;

        public ProductTypeController(IProductTypeService productTypeService, ILogger<ProductTypeController> logger)
        {
            _productTypeService = productTypeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductTypes()
        {
            try
            {
                var result = await _productTypeService.GetProductTypesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get product types error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}