using ECommerce.Server.Services.ClaimsService;
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
        private readonly IClaimsService _claimsService;

        public AuthorizationController(ILogger<AuthorizationController> logger, IClaimsService claimsService)
        {
            _logger = logger;
            _claimsService = claimsService; 
        }

        [HttpGet("authorize")]
        [Authorize]
        public ActionResult GetUserConfirmed()
        {
            try
            {
                var result = _claimsService.GetUserIdFromClaims(User);
                return result.Success ? Ok(new { Message = "You have access to user-level actions and information", UserId = result.Data }) : Unauthorized("User ID is missing in the token.");
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
                var result = _claimsService.GetUserIdFromClaims(User);
                return result.Success ? Ok(new { Message = "You have access to admin-level actions and information", UserId = result.Data }) : Unauthorized("User ID is missing in the token.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"User authorization error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}

