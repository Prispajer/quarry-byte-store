namespace ECommerce.Server.Services.UserService
{
    public interface IUserService
    {
        public Task<ServiceResponse<User>> GetUserByEmailAsync(string email);
        public Task<ServiceResponse<User>> GetUserByEmailAndPasswordAsync(string email, string password);

        public Task<ServiceResponse<User>> CreateNewUserAsync(string email, string password, string name, bool isAdmin);

        public Task<ServiceResponse<User>> CheckUserOldPasswordByIdAsync(int id, string oldPassword);

        public Task<ServiceResponse<User>> ChangeUserPasswordAsync(User user, string newPassword);

    }
}
