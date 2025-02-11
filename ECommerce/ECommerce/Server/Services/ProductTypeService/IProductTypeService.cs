using ECommerce.Shared.Models;
using ECommerce.Shared.Models.Product;

namespace ECommerce.Server.Services.ProductTypeService
{
    public interface IProductTypeService
    {
        Task<ServiceResponse<List<ProductType>>> GetProductTypesAsync();
    }
}