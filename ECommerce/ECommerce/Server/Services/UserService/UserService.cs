using ECommerce.Shared.Models;
using ECommerce.Shared.Models.User;
using ECommerce.Shared.Dto.User;
using ECommerce.Server.Repositories.UserRepository;
using ECommerce.Server.Migrations;

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

        public async Task<ServiceResponse<User>> VerifyUserCredentialsAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user != null && BC.Verify(password, user.PasswordHash))
            {
                return new ServiceResponse<User>
                {
                    Data = user,
                    Success = true
                };
            }

            return new ServiceResponse<User>
            {
                Success = false,
                Message = "Invalid credentials."
            };
        }
        public async Task<ServiceResponse<User>> VerifyUserOldPasswordAsync(int userId, string oldPassword)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

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
        public async Task<ServiceResponse<User>> RegisterUserAsync(string email, string password, string name, bool isAdmin)
        {
            if (await _userRepository.UserExistsByFieldAsync(u => u.Email == email))
            {
                return new ServiceResponse<User>
                {
                    Success = false,
                    Message = "This email is already used."
                };
            }

            if (await _userRepository.UserExistsByFieldAsync(u => u.Name == name))
            {
                return new ServiceResponse<User>
                {
                    Success = false,
                    Message = "This username is already taken."
                };
            }

            var hashedPassword = BC.HashPassword(password);

            var user = new User { Email = email, Name = name, PasswordHash = hashedPassword, IsAdmin = isAdmin };

            await _userRepository.CreateUserAsync(user);

            return new ServiceResponse<User>
            {
                Data = user,
                Success = true,
                Message = "Account created successfully."
            };
        }
        public async Task<ServiceResponse<User>> ChangeUserPasswordAsync(User user, string newPassword)
        {
            if (user == null)
            {
                return new ServiceResponse<User>
                {
                    Data = null,
                    Message = "User does not exist",
                    Success = false
                };
            }

            if (BC.Verify(newPassword, user.PasswordHash))
            {
                return new ServiceResponse<User>
                {
                    Data = null,
                    Message = "New password cannot be previous password",
                    Success = false
                };
            }

            user.PasswordHash = BC.HashPassword(newPassword);
            await _userRepository.UpdateUserAsync(user);
            
            return new ServiceResponse<User>
            {
                Data = user,
                Message = "Password changed successfully",
                Success = true
            };
        }
    }
}
