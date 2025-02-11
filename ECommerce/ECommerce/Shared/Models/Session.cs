using ECommerce.Shared.Models.Cart;

namespace ECommerce.Shared.Models
{
    public class Session
    {
        public string Username { get; set; }
        public string SessionId { get; set; }
        public string TokenId { get; set; }
        public DateTime LastLoginTime { get; set; }
        public List<CartItem> CartItems { get; set; }

    }

}
