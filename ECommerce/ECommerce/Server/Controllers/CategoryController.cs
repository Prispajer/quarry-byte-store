using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Server.Controllers
{
[Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategories()
        {
            try
            {
                var result = await _categoryService.GetCategories();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Category retrieval error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
