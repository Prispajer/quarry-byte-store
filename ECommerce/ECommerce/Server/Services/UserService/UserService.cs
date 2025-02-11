using ECommerce.Shared.Models;
using ECommerce.Shared.Models.User;
using ECommerce.Shared.Dto.User;
using ECommerce.Server.Repositories.UserRepository;

namespace ECommerce.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;
        public UserService(DataContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;

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
            var data = await _context.Users.Where(x => x.Email == email).SingleOrDefaultAsync();
            if (data != null && BC.Verify(password, data.PasswordHash))
            {
                return new ServiceResponse<User>
                {
                    Data = data,
                    Success = true
                };
            }

            return new ServiceResponse<User>
            {
                Data = null,
                Message = "Could not authenticate user",
                Success = false
            };
        }

        public async Task<ServiceResponse<User>> RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            return await _userRepository.CreateNewUserAsync(registerUserDto);
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
            if (!BC.Verify(oldPassword, user.PasswordHash))
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
            if (BC.Verify(newPassword, user.PasswordHash))
            {
                return new ServiceResponse<User>
                {
                    Data = null,
                    Message = "New password cannot be old password",
                    Success = false
                };
            }

            _context.Users.Update(user);
            user.PasswordHash = BC.HashPassword(newPassword);
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
