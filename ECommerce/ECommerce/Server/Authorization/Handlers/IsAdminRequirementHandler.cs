using ECommerce.Server.Requirements;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ECommerce.Server.Authorization.Handlers
{
    public class IsAdminRequirementHandler : AuthorizationHandler<IsAdminRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdminRequirement requirement)
        {
            var userRoleClaim = context.User.FindFirst(
            c => c.Type == ClaimTypes.Role && c.Issuer == "ECommerceServer");

            if (userRoleClaim != null && userRoleClaim.Value == "Admin")
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
