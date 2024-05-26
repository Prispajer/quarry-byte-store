namespace ECommerce.Server.Services.ProductTypeService
{
    public class ProductTypeService: IProductTypeService
    {
        private readonly DataContext _context;

        public ProductTypeService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ProductType>>> GetProductTypesAsync()
        {
            var response = new ServiceResponse<List<ProductType>>
            {
                Data = await _context.ProductTypes.ToListAsync()
            };

            return response;
        }
    }
}
