using ECommerce.Shared.Dto.User;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.User;
using System.Linq.Expressions;

namespace ECommerce.Server.Repositories.UserRepository
{
    public interface IUserRepository
    {
        public Task<User?> GetUserByEmailAsync(string email);
        public Task<User?> GetUserByIdAsync(int userId);
        public Task<bool> UserExistsByFieldAsync(Expression<Func<User, bool>> predicate);
        public Task CreateUserAsync(User user);
        public Task UpdateUserAsync(User user);
    }
}
