namespace ECommerce.Shared.Dto.User
{
    public class ChangeUserPasswordDto
    {
        public int UserId { get; set; }
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
