using ECommerce.Server.Repositories.ProductRepository;
using ECommerce.Server.Services.HelperService;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Product;

namespace ECommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IProductRepository _productRepository;
        private readonly IHelperService _helperService;

        public ProductService(DataContext context, IProductRepository productRepository, IHelperService helperService)
        {
            _context = context;
            _productRepository = productRepository;
            _helperService = helperService;
        }
        public async Task<ServiceResponse<List<Product>>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _helperService.CreateResponse(products, "Products are not available!");
        }
        public async Task<ServiceResponse<Product?>> GetByIdAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            return _helperService.CreateResponse(product, "Product are not available!");
        }
        public async Task<ServiceResponse<List<Product>>> GetByCategoryAsync(string categoryUrl)
        {
            var products = await _productRepository.GetByCategoryAsync(categoryUrl);
            return _helperService.CreateResponse(products, "Products are not available!");
        }
        public async Task<ServiceResponse<List<Product>>> SearchAsync(string searchText)
        {
            var products = await _productRepository.SearchAsync(searchText) ?? new List<Product>();
            return _helperService.CreateResponse(products, "Products are not available!");
        }
        public async Task<ServiceResponse<List<string>>> GetBySearchAsync(string searchText)
        {
            var results = await SearchAsync(searchText);

            List<string> result = new List<string>();

            if (results.Success && results.Data != null)
            {
                var products = results.Data;

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
            }
            return new ServiceResponse<List<string>> { Data = result };
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
