using ECommerce.Shared.Models;

namespace ECommerce.Client.Services.SessionService
{
    public interface ISessionService
    {
        Task<ServiceResponse<Session>> GetSessionAsync();
        Task<ServiceResponse<Session>> UpdateSessionAsync(Session session);
    }
}
