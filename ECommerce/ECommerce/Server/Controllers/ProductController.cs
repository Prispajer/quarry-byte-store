using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Product;
using ECommerce.Shared.Dto.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetAll()
        {
            try
            {
                return Ok(await _productService.GetAllAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Products retrieval error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetById(int productId)
        {
            try
            {
                return Ok(await _productService.GetByIdAsync(productId));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Product retrieval error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetByCategory(string categoryUrl)
        {
            try
            {
                return Ok(await _productService.GetByCategoryAsync(categoryUrl));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Products by category retrieval error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> SearchProducts(string searchText)
        {
            try
            {
                return Ok(await _productService.SearchProducts(searchText));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Search product retrieval error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("searchsuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductSearchSuggestions(string searchText)
        {
            try
            {
                return Ok(await _productService.GetProductSearchSuggestions(searchText));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Product suggestions retrieval error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("add")]
        [Authorize(Policy = "IsAnAdmin")]
        public async Task<ActionResult<ServiceResponse<Product>>> AddProduct(AddProductDto addProductDto)
        {
            try
            {
                var result = await _productService.AddProductAsync(addProductDto.Title, addProductDto.Description, addProductDto.ImageUrl, addProductDto.CategoryId);
                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Add product error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPatch("edit/{id}")]
        [Authorize(Policy = "IsAnAdmin")]
        public async Task<ActionResult<ServiceResponse<Product>>> EditProduct(EditProductDto editProductDto)
        {
            try
            {
                var result = await _productService.EditProductAsync(editProductDto.Id, editProductDto.Title, editProductDto.Description, editProductDto.ImageUrl);
                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Edit product error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Policy = "IsAnAdmin")]
        public async Task<ActionResult<ServiceResponse<Product>>> DeleteProduct(int id)
        {
            try
            {
                var result = await _productService.DeleteProductAsync(id);
                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Delete product error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
