﻿namespace ECommerce.Shared.Dto.User
{
    public class ResetUserPasswordDto
    {
        public int Id { get; set; }
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
