using ECommerce.Server.Repositories.ProductRepository;
using ECommerce.Shared.Models.Product;

public class ProductRepository : IProductRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetProductByIdAsync(int productId)
    {
        return await _context.Products
            .Include(p => p.Variants)
            .ThenInclude(v => v.ProductType)
            .FirstOrDefaultAsync(p => p.Id == productId);
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _context.Products.Include(p => p.Variants).ToListAsync();
    }

    public async Task<List<Product>> GetProductsByCategoryAsync(string categoryUrl)
    {
        return await _context.Products
            .Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
            .Include(p => p.Variants)
            .ToListAsync();
    }

    public async Task<List<Product>> SearchProductsAsync(string searchText)
    {
        return await _context.Products
            .Where(p => p.Title.ToLower().Contains(searchText.ToLower()) ||
                        p.Description.ToLower().Contains(searchText.ToLower()))
            .ToListAsync();
    }

    public async Task AddProductAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}
