namespace ECommerce.Server.Services.SessionService
{
    public interface ISessionService
    {
        Task<ServiceResponse<Session>> SetSessionAsync(Session session);
        Task<ServiceResponse<Session>> GetSessionAsync();
        Task<ServiceResponse<Session>> ClearSessionAsync();
    }
}
