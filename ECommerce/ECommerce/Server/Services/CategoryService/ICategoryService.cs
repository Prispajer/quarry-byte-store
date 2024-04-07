namespace ECommerce.Server.Services.CategoryService
{
    public interface ICategoryService
    {
        //task returning service response with the list of categories
        Task<ServiceResponse<List<Category>>> GetCategories();
    }
}
