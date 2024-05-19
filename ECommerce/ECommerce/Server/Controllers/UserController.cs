using ECommerce.Server.Services.TokenService;
using ECommerce.Server.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }


        [HttpGet("login")]
        public async Task<ActionResult<string>> GetUserByEmailAndPassword(string email, string password)
        {
            var result = await _userService.GetUserByEmailAndPasswordAsync(email, password);
            if (!result.Success || result.Data == null)
            {
                return Unauthorized(string.Empty);
            }
            else
            {
                string token = _tokenService.GenerateToken(result.Data);
                return Ok(token);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<User>>> CreateUser(string email, string password, string name, bool isAdmin)
        {;
            var result = await _userService.CreateNewUserAsync(email, password, name, isAdmin);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return Conflict(result);
            }
        }

        [HttpPatch("resetpassword")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<User>>> ChangePassword(int id, string oldPassword, string newPassword)
        {
            var result = await _userService.CheckUserOldPasswordByIdAsync(id, oldPassword);
            if (!result.Success || result.Data == null)
            {
                return Unauthorized(result);
            }
            result = await _userService.ChangeUserPasswordAsync(result.Data,  newPassword);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return Conflict(result);
            }
        }

        [HttpPatch("forgotpassword")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<User>>> ChangeForgottenPassword(string email, string newPassword)
        {
            var result = await _userService.GetUserByEmailAsync(email);
            if (!result.Success || result.Data == null)
            {
                return BadRequest(result);
            }
            result = await _userService.ChangeUserPasswordAsync(result.Data, newPassword);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return Conflict(result);
            }
        }
    }
}