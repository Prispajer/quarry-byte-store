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

        public ProductTypeController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductTypes()
        {
            var result = await _productTypeService.GetProductTypesAsync();
            return Ok(result);
        }
    }
}