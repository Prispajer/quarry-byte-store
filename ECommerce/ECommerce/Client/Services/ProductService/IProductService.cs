﻿namespace ECommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        //event- change product list
        event Action ProductsChanged;
        List<Product> Products { get; set; }
        Task GetProducts(string? categoryUrl = null);

        Task<ServiceResponse<Product>> GetProduct(int productId);
    }
}
