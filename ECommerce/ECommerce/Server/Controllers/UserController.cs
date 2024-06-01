using ECommerce.Server.Services.SessionService;
using ECommerce.Server.Services.TokenService;
using ECommerce.Server.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<ActionResult<User>> GetUserByEmailAndPassword(UserLoginRequest request)
        {
            var result = await _userService.GetUserByEmailAndPasswordAsync(request.Email, request.Password);
            if (!result.Success || result.Data == null)
            {
                return Unauthorized("Could not authenticate user");
            }

            string token = _tokenService.GenerateToken(result.Data);

            var session = new Session
            {
                Username = result.Data.Email,
                SessionId = Guid.NewGuid().ToString(),
                LastLoginTime = DateTime.UtcNow,
                TokenId = token
            };

            await _sessionService.SetSessionAsync(session);

            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<User>>> CreateUser(UserRegistrationRequest request)
        {
            var result = await _userService.CreateNewUserAsync(request.Email, request.Password, request.Name, request.IsAdmin);
            if (result.Success)
            {
                return Ok(result);
            }
            return Conflict(result);
        }

        [Authorize]
        [HttpPatch("resetpassword")]
        public async Task<ActionResult<ServiceResponse<User>>> ChangePassword(int id, string oldPassword, string newPassword)
        {
            var authorizationResult = await _authorizationService
                .AuthorizeAsync(User, id, "IsSameUser");
            if (!authorizationResult.Succeeded)
            {
                return Unauthorized(null);
            }

            var result = await _userService.CheckUserOldPasswordByIdAsync(id, oldPassword);
            if (!result.Success || result.Data == null)
            {
                return Unauthorized(result);
            }
            result = await _userService.ChangeUserPasswordAsync(result.Data, newPassword);
            if (result.Success)
            {
                return Ok(result);
            }
            return Conflict(result);
        }

        [Authorize]
        [HttpPatch("forgotpassword")]
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
            return Conflict(result);
        }

    }
}
