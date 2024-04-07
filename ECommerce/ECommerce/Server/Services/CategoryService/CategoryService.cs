namespace ECommerce.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        
        private readonly DataContext _context;
        //get access to categories        
        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            //get categories with data context - return new response with product categories
            var categories = await _context.Categories.ToListAsync();
            return new ServiceResponse<List<Category>>
            {
                //set Data to categories
                Data = categories
            };
        }
    }
}
