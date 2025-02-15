namespace ECommerce.Shared.Dto.ProductVariant
{
    public class EditProductVariantDto
    {
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
    }
}
