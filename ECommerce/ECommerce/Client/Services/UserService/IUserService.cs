using System.Threading.Tasks;
using ECommerce.Shared.Dto.User;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.User;

namespace ECommerce.Client.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> LoginUserAsync(LoginUserDto loginUserDto);
        Task<ServiceResponse<User>> RegisterUserAsync(RegisterUserDto registerUserDto);
        Task<ServiceResponse<User>> ChangeUserPasswordAsync(ResetUserPasswordDto changeUserPasswordDto);
        Task<ServiceResponse<User>> ChangeUserForgottenPasswordAsync(ChangeUserPasswordDto changeUserForgottenPasswordDto);
    }
}

