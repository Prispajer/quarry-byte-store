using System.Threading.Tasks;
using ECommerce.Shared;

namespace ECommerce.Client.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> LoginAsync(UserLoginRequest request);
        Task<ServiceResponse<User>> RegisterAsync(UserRegistrationRequest request);
        Task<ServiceResponse<User>> ChangePasswordAsync(int id, string oldPassword, string newPassword);
        Task<ServiceResponse<User>> ChangeForgottenPasswordAsync(string email, string newPassword);
    }
}

