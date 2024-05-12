using System;

namespace ECommerce.Server.Services.UserService
{
    public interface IUserService
    {
        public Task<ServiceResponse<User>> GetUserByEmailAndPasswordAsync(string email, string password);
    }

}
