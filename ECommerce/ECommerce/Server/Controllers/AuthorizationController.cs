using ECommerce.Server.Services.UserAuthorizationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace ECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILogger<AuthorizationController> _logger;
        private readonly IUserAuthorizationService _userAuthorizationService;

        public AuthorizationController(ILogger<AuthorizationController> logger, IUserAuthorizationService userAuthorizationService)
        {
            _logger = logger;
            _userAuthorizationService = userAuthorizationService; 
        }

        [HttpGet("authorize")]
        [Authorize]
        public ActionResult GetUserConfirmed()
        {
            try
            {
                var user = _userAuthorizationService.GetUserIdFromClaims(User); 
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User ID is missing in the token.");
                }
                return Ok(new { Message = "You have access to user-level actions and information", UserId = userId });
            }
            catch (Exception ex)
            {
                _logger.LogError($"User authorization error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("authorizeAdmin")]
        [Authorize(Policy = "IsAnAdmin")]
        public ActionResult GetAdminPrivilegeConfirmed()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return Ok(new { Message = "You have access to admin-level actions and information", UserId = userId });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Admin authorization error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
