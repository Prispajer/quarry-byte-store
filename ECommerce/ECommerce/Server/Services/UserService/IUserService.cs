using ECommerce.Shared.Dto.User;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.User;

namespace ECommerce.Server.Services.UserService
{
    public interface IUserService
    {
        public Task<ServiceResponse<User>> GetUserByEmailAsync(string email);
        public Task<ServiceResponse<User>> GetUserByEmailAndPasswordAsync(string email, string password);

        public Task<ServiceResponse<User>> RegisterUserAsync(RegisterUserDto registerUserDto);

        public Task<ServiceResponse<User>> CheckUserOldPasswordByIdAsync(int id, string oldPassword);

        public Task<ServiceResponse<User>> ChangeUserPasswordAsync(User user, string newPassword);

    }
}
