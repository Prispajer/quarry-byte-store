using ECommerce.Shared.Models;
using System.Security.Claims;

namespace ECommerce.Server.Services.UserAuthorizationService
{
    public interface IUserAuthorizationService
    {
        ServiceResponse<string> GetUserIdFromClaims(ClaimsPrincipal user);
    }
}
