using ECommerce.Shared.Models.User;

namespace ECommerce.Shared.Dto.User
{
    public class ChangeUserPasswordDto
    {
        public int Id { get; set; }
        public string NewPassword { get; set; } = string.Empty;
    }}

