namespace ECommerce.Shared.Dto.Cart
{
    public class GetCartProductsDto
    {
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
