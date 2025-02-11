namespace ECommerce.Shared.Dto.User
{
    public class ChangeUserForgottenPasswordDto
    {
        public string Email { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
