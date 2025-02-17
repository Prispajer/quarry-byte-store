using ECommerce.Shared.Models;

namespace ECommerce.Server.Services.SessionService
{
    public interface ISessionService
    {
        ServiceResponse<Session> GetSession();
    }
}