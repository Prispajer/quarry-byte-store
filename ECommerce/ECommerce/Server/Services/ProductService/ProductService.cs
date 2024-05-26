namespace ECommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();

            var product = await _context.Products
                .Include(p => p.Variants)
                .ThenInclude(v => v.ProductType)
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
            {
                response.Success = false;
                response.Message = "Product is not available";
            }
            else
            {
                response.Data = product;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products.Include(p => p.Variants).ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                    .Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
                    .Include(p => p.Variants)
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            var products = await FindProductsBySearchText(searchText);

            List<string> result = new List<string>();

            foreach (var product in products)
            {
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if (product.Description != null)
                {
                    var punctuation = product.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = product.Description.Split()
                        .Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                            && !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> { Data = result };
        }

        public async Task<ServiceResponse<List<Product>>> SearchProducts(string searchText)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await FindProductsBySearchText(searchText)
            };

            return response;
        }

        private async Task<List<Product>> FindProductsBySearchText(string searchText)
        {
            return await _context.Products.Where(p => p.Title.ToLower().Contains(searchText.ToLower()) || p.Description.ToLower().Contains(searchText.ToLower())).ToListAsync();
        }

        public async Task<ServiceResponse<Product>> AddProductAsync(string title, string description, string imageUrl, int categoryId)
        {
            var category = await _context.Categories.Where(p => p.Id == categoryId).SingleOrDefaultAsync();

            if (category == null)
            {
                return new ServiceResponse<Product>
                {
                    Data = null,
                    Success = false,
                    Message = "No Category found for given categoryId"
                };
            }

            var product = new Product()
            {
                Title = title,
                Description = description,
                ImageUrl = imageUrl,

                Category = category,
                CategoryId = categoryId
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return new ServiceResponse<Product>
            {
                Data = product,
                Success = true,
                Message = "Product added successfully"
            };
        }

        public async Task<ServiceResponse<Product>> EditProductAsync(int id, string? title, string? description, string? imageUrl)
        {
            var product = await _context.Products.Where(p => p.Id == id).SingleOrDefaultAsync();
            if (product == null)
            {
                return new ServiceResponse<Product>
                {
                    Data = null,
                    Success = false,
                    Message = "No Product found for given Id"
                };
            }

            _context.Products.Update(product);
            product.Title = title ?? product.Title;
            product.Description = description ?? product.Description;
            product.ImageUrl = imageUrl ?? product.ImageUrl;
            _context.SaveChanges();

            return new ServiceResponse<Product>
            {
                Data = product,
                Success = true,
                Message = "Product updated successfully"
            };
        }

        public async Task<ServiceResponse<Product>> DeleteProductAsync(int id)
        {
            var product = await _context.Products.Where(p => p.Id == id).SingleOrDefaultAsync();
            if (product == null)
            {
                return new ServiceResponse<Product>
                {
                    Data = null,
                    Success = false,
                    Message = "No Product found for given Id"
                };
            }
            _context.Products.Remove(product);
            _context.SaveChanges();

            return new ServiceResponse<Product>
            {
                Data = product,
                Success = true,
                Message = "Product removed successfully"
            };
        }
    }
}
