using ECommerce.Server.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("login")]
        public async Task<ActionResult<ServiceResponse<User>>> GetUserByEmailAndPassword(string email, string password)
        {
            var result = await _userService.GetUserByEmailAndPasswordAsync(email, password);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized(result);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<Product>>> CreateUser(string name, string email, string password)
        {;
            throw new NotImplementedException();
            // return Ok(result);
        }

        [HttpPatch("resetpassword")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> ChangePassword(int id, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
            // return Ok(result);
        }

        [HttpPatch("forgotpassword")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> ChangeForgottenPassword(string email, string newPassword)
        {
            throw new NotImplementedException();
            // return Ok(result);
        }
    }
}