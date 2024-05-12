using System;

namespace ECommerce.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<User>> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            var data = await _context.Users.Where(x => x.Email == email && x.Password == password).SingleOrDefaultAsync();
            var response = new ServiceResponse<User>
            {
                Data = data,
                Success = data != default(User)
            };

            return response;
        }
    }
}
