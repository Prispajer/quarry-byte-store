using ECommerce.Server.Services.SessionService;
using ECommerce.Server.Services.TokenService;
using ECommerce.Server.Services.UserService;
using ECommerce.Shared.Dto.User;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.User;
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
        private readonly IAuthorizationService _authorizationService;
        private readonly ISessionService _sessionService;

        public UserController(IUserService userService, ITokenService tokenService, IAuthorizationService authorizationService, ISessionService sessionService)
        {
            _userService = userService;
            _tokenService = tokenService;
            _authorizationService = authorizationService;
            _sessionService = sessionService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> LoginUser(LoginUserDto loginUserDto)
        {
            var result = await _userService.VerifyUserCredentialsAsync(loginUserDto.Email, loginUserDto.Password);

            if (!result.Success || result.Data == null)
            {
                return Unauthorized("Could not authenticate user");
            }

            string token = _tokenService.GenerateToken(result.Data);

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(30)
            };

            Response.Cookies.Append("AuthToken", token, cookieOptions);

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<User>>> RegisterUser(RegisterUserDto registerUserDto)
        {
            var result = await _userService.RegisterUserAsync(registerUserDto.Email, registerUserDto.Password, registerUserDto.Name, registerUserDto.IsAdmin);

            if (result.Success)
            {
                return Ok(result);
            }

            return Conflict(result);
        }

        [Authorize]
        [HttpPatch("resetpassword")]
        public async Task<ActionResult<ServiceResponse<User>>> ResetUserPassword(ResetUserPasswordDto resetUserPasswordDto)
        {
            var authorizationResult = await _authorizationService
                .AuthorizeAsync(User, resetUserPasswordDto.UserId, "IsSameUser");
            if (!authorizationResult.Succeeded)
            {
                return Unauthorized(null);
            }

            var result = await _userService.VerifyUserOldPasswordAsync(resetUserPasswordDto.UserId, resetUserPasswordDto.OldPassword);
            if (!result.Success || result.Data == null)
            {
                return Unauthorized(result);
            }
            result = await _userService.ChangeUserPasswordAsync(result.Data, resetUserPasswordDto.NewPassword);
            if (result.Success)
            {
                return Ok(result);
            }
            return Conflict(result);
        }

        [Authorize]
        [HttpPatch("forgotpassword")]
        public async Task<ActionResult<ServiceResponse<User>>> ChangeUserPassword(User user, string newPassword)
        {
            var result = await _userService.ChangeUserPasswordAsync(user, newPassword);
            if (result.Success)
            {
                return Ok(result);
            }
            return Conflict(result);
        }
    }
}
