using ECommerce.Shared.Models.User;

namespace ECommerce.Server.Services.TokenService
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
