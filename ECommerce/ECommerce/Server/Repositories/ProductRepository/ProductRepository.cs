using ECommerce.Server.Repositories.ProductRepository;
using ECommerce.Shared.Models.Product;

public class ProductRepository : IProductRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.Include(p => p.Variants).ToListAsync();
    }
    public async Task<Product?> GetByIdAsync(int productId)
    {
        return await _context.Products
            .Include(p => p.Variants)
            .ThenInclude(v => v.ProductType)
            .FirstOrDefaultAsync(p => p.Id == productId);
    }
    public async Task<List<Product>> GetByCategoryAsync(string categoryUrl)
    {
        return await _context.Products
            .Where(p => p.Category != null && p.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
            .Include(p => p.Variants)
            .ToListAsync();
    }
    public async Task<List<Product>> SearchAsync(string searchText)
    {
        return await _context.Products
            .Where(p => p.Title.ToLower().Contains(searchText.ToLower()) ||
                        p.Description.ToLower().Contains(searchText.ToLower()))
            .ToListAsync();
    }
    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}
