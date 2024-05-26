using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.IO;

namespace ECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        [HttpGet("authorize")]
        [Authorize]
        public ActionResult GetUserConfirmed()
        {
            return Ok("You have access to user-level actions and information");
        }

        [HttpGet("authorizeAdmin")]
        [Authorize(Policy = "IsAnAdmin")]
        public ActionResult GetAdminPrivilegeConfirmed()
        {
            return Ok("You have access to admin-level actions and information");
        }
    }
}
