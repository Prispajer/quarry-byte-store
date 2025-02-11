using ECommerce.Shared.Dto.User;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.User;

namespace ECommerce.Server.Repositories.UserRepository
{
    public interface IUserRepository
    {
        public Task<ServiceResponse<User>> VerifyUserCredentialsAsync(LoginUserDto loginUserDto);
        public Task<ServiceResponse<User>> VerifyOldPasswordAsync(int id, string oldPassword);

        public Task<ServiceResponse<User>> CreateNewUserAsync(RegisterUserDto registerUserDto);

        public Task<ServiceResponse<User>> UpdateUserPasswordAsync(User user, string newPassword);
    }
}
