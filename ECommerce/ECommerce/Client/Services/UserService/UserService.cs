using ECommerce.Client.Services.HttpService;
using ECommerce.Shared.Dto.User;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.User;

namespace ECommerce.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IHttpService _httpService;

        public UserService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<ServiceResponse<User>> LoginUserAsync(LoginUserDto loginUserDto)
        {
            return await _httpService.SendRequestAsync<User>(HttpMethod.Post, "api/user/login", loginUserDto);
        }

        public async Task<ServiceResponse<User>> RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            return await _httpService.SendRequestAsync<User>(HttpMethod.Post, "api/user/register", registerUserDto);
        }

        public async Task<ServiceResponse<User>> ChangeUserPasswordAsync(ResetUserPasswordDto resetUserPasswordDto)
        {
            return await _httpService.SendRequestAsync<User>(HttpMethod.Patch, $"api/user/resetpassword?id={resetUserPasswordDto.Id}&oldPassword={resetUserPasswordDto.OldPassword}&newPassword={resetUserPasswordDto.NewPassword}", null);
        }

        public async Task<ServiceResponse<User>> ChangeUserForgottenPasswordAsync(ChangeUserPasswordDto changeUserPasswordDto)
        {
            return await _httpService.SendRequestAsync<User>(HttpMethod.Patch, $"api/user/forgotpassword?id={changeUserPasswordDto.Id}&newPassword={changeUserPasswordDto.NewPassword}", null);
        }
    }
}
