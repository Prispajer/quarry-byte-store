using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ECommerce.Server.Services.TokenService;
using ECommerce.Server.Services.UserService;
using ECommerce.Shared.Dto.User;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.User;

namespace ECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IAuthorizationService _authorizationService;
        private readonly ILogger<UserController> _logger;

        public UserController(
            IUserService userService, 
            ITokenService tokenService, 
            IAuthorizationService authorizationService,
            ILogger<UserController> logger)
        {
            _userService = userService;
            _tokenService = tokenService;
            _authorizationService = authorizationService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> LoginUser(LoginUserDto loginUserDto)
        {
            try
            {
                var result = await _userService.VerifyUserCredentialsAsync(loginUserDto.Email, loginUserDto.Password);

                if (!result.Success || result.Data == null)
                {
                    _logger.LogWarning("Failed login attempt for email: {Email}", loginUserDto.Email);
                    return Unauthorized("Could not authenticate user");
                }

                string token = _tokenService.GenerateToken(result.Data);
                Response.Cookies.Append("AuthToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddMinutes(30)
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Login error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<User>>> RegisterUser(RegisterUserDto registerUserDto)
        {
            try
            {
                var result = await _userService.RegisterUserAsync(registerUserDto.Email, registerUserDto.Password, registerUserDto.Name, registerUserDto.IsAdmin);
                return result.Success ? Ok(result) : Conflict(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Registration error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

         [Authorize]
        [HttpPatch("resetpassword")]
        public async Task<ActionResult<ServiceResponse<User>>> ResetUserPassword(ResetUserPasswordDto resetUserPasswordDto)
        {
            try
            {
                var authorizationResult = await _authorizationService
                    .AuthorizeAsync(User, resetUserPasswordDto.Id, "IsSameUser");

                if (!authorizationResult.Succeeded)
                {
                    return Forbid("You are not authorized to change this password.");
                }

                var result = await _userService.VerifyUserOldPasswordAsync(resetUserPasswordDto.Id, resetUserPasswordDto.OldPassword);
                if (!result.Success || result.Data == null)
                {
                    _logger.LogWarning("Invalid old password for user ID: {UserId}", resetUserPasswordDto.Id);
                    return Unauthorized("Old password is incorrect.");
                }

                var updateResult = await _userService.ChangeUserPasswordAsync(result.Data.Id, resetUserPasswordDto.NewPassword);
                return updateResult.Success ? Ok(updateResult) : Conflict(updateResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Password reset error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }


        [Authorize]
        [HttpPatch("forgotpassword")]
        public async Task<ActionResult<ServiceResponse<User>>> ChangeUserPassword(ChangeUserPasswordDto changeUserPasswordDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(changeUserPasswordDto.NewPassword) || changeUserPasswordDto.NewPassword.Length < 8)
                {
                    return BadRequest("New password must be at least 8 characters long.");
                }

                var result = await _userService.ChangeUserPasswordAsync(changeUserPasswordDto.Id, changeUserPasswordDto.NewPassword);
                return result.Success ? Ok(result) : Conflict(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Forgot password error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
