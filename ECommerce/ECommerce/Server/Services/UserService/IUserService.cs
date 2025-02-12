using ECommerce.Shared.Dto.User;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.User;

namespace ECommerce.Server.Services.UserService
{
    public interface IUserService
    {
        public Task<ServiceResponse<User>> VerifyUserCredentialsAsync(string email, string password);
        public Task<ServiceResponse<User>> VerifyUserOldPasswordAsync(int userId, string oldPassword);
        public Task<ServiceResponse<User>> RegisterUserAsync(string email, string password, string name, bool isAdmin);
        public Task<ServiceResponse<User>> ChangeUserPasswordAsync(User user, string newPassword);
    }
}
