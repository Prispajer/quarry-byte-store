using ECommerce.Shared.Models;

namespace ECommerce.Client.Services.AuthService
{
    public interface IAuthService
    {
        event Action? OnChange;
        Task<Session?> GetCurrentSession();
        Task SetCurrentSession(Session session);
        Task ClearCurrentSession();
    }
}