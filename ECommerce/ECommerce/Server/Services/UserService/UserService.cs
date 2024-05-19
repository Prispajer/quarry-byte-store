namespace ECommerce.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<User>> GetUserByEmailAsync(string email)
        {
            var data = await _context.Users.Where(x => x.Email == email).SingleOrDefaultAsync();
            var response = new ServiceResponse<User>
            {
                Data = data,
                Success = data != null
            };

            return response;
        }
        public async Task<ServiceResponse<User>> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            var data = await _context.Users.Where(x => x.Email == email && x.Password == password).SingleOrDefaultAsync();
            var response = new ServiceResponse<User>
            {
                Data = data,
                Success = data != null
            };

            return response;
        }

        private async Task<bool> CheckIfUserWithEmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email);
        }

        private async Task<bool> CheckIfUserWithNameExistsAsync(string name)
        {
            return await _context.Users.AnyAsync(x => x.Name == name);
        }

        public async Task<ServiceResponse<User>> CreateNewUserAsync(string email, string password, string name)
        {
            if (await CheckIfUserWithEmailExistsAsync(email))
            {
                return new ServiceResponse<User>
                {
                    Data = null,
                    Message = "This email is already used",
                    Success = false
                };
            }
            if (await CheckIfUserWithNameExistsAsync(name))
            {
                return new ServiceResponse<User>
                {
                    Data = null,
                    Message = "This username is already used",
                    Success = false
                };
            }
            var user = new User { Email = email, Password = password, Name = name };
            _context.Users.Add(user);
            _context.SaveChanges();
            var response = new ServiceResponse<User>
            {
                Data = user,
                Message = "Account created successfully",
                Success = true
            };

            return response;
        }

        private async Task<User?> GetUserById(int id)
        {
            return await _context.Users.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<ServiceResponse<User>> CheckUserOldPasswordByIdAsync(int id, string oldPassword)
        {
            var user = await GetUserById(id);
            if (user == null)
            {
                return new ServiceResponse<User>
                {
                    Data = null,
                    Message = "User does not exist",
                    Success = false
                };
            }
            if (user.Password != oldPassword)
            {
                return new ServiceResponse<User>
                {
                    Data = null,
                    Message = "Incorrect old password",
                    Success = false
                };
            }
            return new ServiceResponse<User>
            {
                Data = user,
                Message = "User authenticated",
                Success = true
            };
        }

        public async Task<ServiceResponse<User>> ChangeUserPasswordAsync(User user, string newPassword)
        {
            if (user.Password == newPassword)
            {
                return new ServiceResponse<User>
                {
                    Data = null,
                    Message = "New password cannot be old password",
                    Success = false
                };
            }

            _context.Users.Update(user);
            user.Password = newPassword;
            await _context.SaveChangesAsync();
            
            return new ServiceResponse<User>
            {
                Data = user,
                Message = "Password changed successfully",
                Success = true
            };
        }
    }
}
