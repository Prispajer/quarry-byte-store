using ECommerce.Server.Repositories.CategoryRepository;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Product;

namespace ECommerce.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        
        private readonly DataContext _context;
        private readonly ICategoryRepository _categoryReposiory;

        public CategoryService(DataContext context, ICategoryRepository categoryRepository)
        {
            _context = context;
            _categoryReposiory = categoryRepository;
        }

        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            var categories = await _categoryReposiory.GetCategoriesAsync();
            return new ServiceResponse<List<Category>>
            {
                Data = categories
            };
        }
    }
}
