using System.Linq.Expressions;
using ECommerce.Shared.Dto.User;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.User;

namespace ECommerce.Server.Repositories.UserRepository
{
    public class UserRepository: IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<User>> VerifyUserCredentialsAsync(LoginUserDto loginUserDto)
        {
            var data = await _context.Users.Where(x => x.Email == loginUserDto.Email).SingleOrDefaultAsync();
            if (data != null && BC.Verify(loginUserDto.Password, data.PasswordHash))
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

        public async Task<ServiceResponse<User>> VerifyOldPasswordAsync(int id, string oldPassword)
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

        public async Task<ServiceResponse<User>> CreateNewUserAsync(RegisterUserDto registerUserDto)
        {
            string passwordHash = BC.HashPassword(registerUserDto.Password);

            if (await GetUserByPredicateAnyAsync(u => u.Email == registerUserDto.Email))
            {
                return new ServiceResponse<User>
                {
                    Data = null,
                    Message = "This email is already used",
                    Success = false
                };
            }
            if (await GetUserByPredicateAnyAsync(u => u.Name == registerUserDto.Name))
            {
                return new ServiceResponse<User>
                {
                    Data = null,
                    Message = "This username is already used",
                    Success = false
                };
            }

            var user = new User { Email = registerUserDto.Email, PasswordHash = passwordHash, Name = registerUserDto.Name, IsAdmin = registerUserDto.IsAdmin };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var response = new ServiceResponse<User>
            {
                Data = user,
                Message = "Account created successfully",
                Success = true
            };

            return response;
        }

        public async Task<ServiceResponse<User>> UpdateUserPasswordAsync(User user, string newPassword)
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

        private async Task<bool> GetUserByPredicateAnyAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.AnyAsync(predicate);
        }

        private async Task<User?> GetUserById(int id)
        {
            return await _context.Users.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        private async Task<ServiceResponse<User>> GetUserByEmailAsync(string email)
        {
            var data = await _context.Users.Where(x => x.Email == email).SingleOrDefaultAsync();
            var response = new ServiceResponse<User>
            {
                Data = data,
                Success = data != null
            };

            return response;
        }
    }
}

