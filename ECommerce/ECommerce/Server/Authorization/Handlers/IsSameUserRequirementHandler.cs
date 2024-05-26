using ECommerce.Server.Authorization.Requirements;
using ECommerce.Server.Requirements;
using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace ECommerce.Server.Authorization.Handlers
{
    public class IsSameUserRequirementHandler: AuthorizationHandler<IsSameUserRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsSameUserRequirement requirement)
        {
            if (context.Resource == null)
            {
                return Task.CompletedTask;
            }

            string? userIdString = context.Resource.ToString();

            var userRoleClaim = context.User.FindFirst(
                c => c.Type == ClaimTypes.NameIdentifier && c.Issuer == "ECommerceServer");

            if (userRoleClaim != null && userIdString != null && userRoleClaim.Value == userIdString)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
