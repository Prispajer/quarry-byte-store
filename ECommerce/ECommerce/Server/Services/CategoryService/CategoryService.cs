using ECommerce.Server.Repositories.CategoryRepository;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Product;

namespace ECommerce.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        
        private readonly ICategoryRepository _categoryReposiory;

        public CategoryService(DataContext context, ICategoryRepository categoryRepository)
        {
            _categoryReposiory = categoryRepository;
        }

        public async Task<ServiceResponse<List<Category>>> GetCategoriesAsync()
        {
            var categories = await _categoryReposiory.GetCategoriesToListAsync();

            return new ServiceResponse<List<Category>>
            {
                Data = categories
            };
        }
    }
}
