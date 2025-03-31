using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Product;

namespace ECommerce.Server.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<Category>>> GetCategoriesAsync();
    }
}
