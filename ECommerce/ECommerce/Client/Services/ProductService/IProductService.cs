﻿using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Product;

namespace ECommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        //event- change product list
        event Action ProductsChanged;
        string Message { get; set; }
        List<Product> Products { get; set; }
        Task GetProducts(string? categoryUrl = null);

        Task<ServiceResponse<Product>> GetProduct(int productId);

        Task SearchProducts(string searchText);
        Task<List<string>> GetProductSearchSuggestions(string searchText);
    }
}
