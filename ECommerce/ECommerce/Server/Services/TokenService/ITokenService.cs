using ECommerce.Shared.Models;
using ECommerce.Shared.Models.User;

namespace ECommerce.Server.Services.TokenService
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        Session DecodeToken(string token);
    }
}
