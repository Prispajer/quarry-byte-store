using ECommerce.Shared.Models;

namespace ECommerce.Client.Services.AuthService
{
    public interface IAuthService
    {
        Session? GetCurrentSession();
        void SetCurrentSession(Session session);
        void ClearCurrentSession();
    }
}