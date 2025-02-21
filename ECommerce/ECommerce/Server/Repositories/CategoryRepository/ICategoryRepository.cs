using ECommerce.Shared.Models.Product;

namespace ECommerce.Server.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesAsync();
    }
}
