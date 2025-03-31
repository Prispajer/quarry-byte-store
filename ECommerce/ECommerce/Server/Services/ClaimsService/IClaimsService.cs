using ECommerce.Shared.Models;
using System.Security.Claims;

namespace ECommerce.Server.Services.ClaimsService
{
    public interface IClaimsService
    {
        ServiceResponse<string> GetUserIdFromClaims(ClaimsPrincipal user);
    }
}
