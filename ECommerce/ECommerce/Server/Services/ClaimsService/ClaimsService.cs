using ECommerce.Shared.Models;
using System.Security.Claims;


namespace ECommerce.Server.Services.ClaimsService
{
    public class ClaimsService: IClaimsService
    {
        public ServiceResponse<string> GetUserIdFromClaims(ClaimsPrincipal user)
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return string.IsNullOrEmpty(userId)
                         ? new ServiceResponse<string> { Data = null, Success = false, Message = "User ID wasn't found in the token!" }
                         : new ServiceResponse<string> { Data = userId, Success = true };
        }
    }
}
