namespace ECommerce.Client.Services.CategoryService
{
    public interface ICategoryService
    {
        //get,set list of categories
        List<Category> Categories { get; set; }

        //asynchronously retrieves categories
        Task GetCategories();
    }
}
