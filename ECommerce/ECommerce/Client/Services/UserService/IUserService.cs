using System.Threading.Tasks;
using ECommerce.Shared;

namespace ECommerce.Client.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> LoginAsync(string email, string password);
        Task<ServiceResponse<User>> RegisterAsync(string email, string password, string name, bool isAdmin);
        Task<ServiceResponse<User>> ChangePasswordAsync(int id, string oldPassword, string newPassword);
        Task<ServiceResponse<User>> ChangeForgottenPasswordAsync(string email, string newPassword);
    }
}

