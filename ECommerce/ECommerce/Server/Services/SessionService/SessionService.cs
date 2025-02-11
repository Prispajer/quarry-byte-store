using System.Text.Json;
using System.Threading.Tasks;
using ECommerce.Shared.Models;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Server.Services.SessionService
{
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor _httpContext;

        public SessionService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }


        public async Task<ServiceResponse<Session>> SetSessionAsync(Session session)
        {
            var sessionData = JsonSerializer.Serialize(session);
            _httpContext.HttpContext.Session.SetString("UserSession", sessionData);

            var response = new ServiceResponse<Session>
            {
                Data = session,
                Success = true
            };

            return response;
        }


        public async Task<ServiceResponse<Session>> GetSessionAsync()
        {
            var sessionData = _httpContext.HttpContext.Session.GetString("UserSession");

            if (string.IsNullOrEmpty(sessionData))
            {
                return new ServiceResponse<Session>
                {
                    Data = null,
                    Success = false,
                    Message = "Session not found or empty"
                };
            }

            var session = JsonSerializer.Deserialize<Session>(sessionData);

            if (session == null)
            {
                return new ServiceResponse<Session>
                {
                    Data = null,
                    Success = false,
                    Message = "Session is invalid or incomplete"
                };
            }

            return new ServiceResponse<Session>
            {
                Data = session,
                Success = true
            };
        }

        public async Task<ServiceResponse<Session>> ClearSessionAsync()
        {
            _httpContext.HttpContext.Session.Remove("UserSession");

            return new ServiceResponse<Session>
            {
                Success = true
            };
        }

        public async Task<ServiceResponse<Session>> UpdateSessionAsync(Session session)
        {
            var sessionData = JsonSerializer.Serialize(session);
            _httpContext.HttpContext.Session.SetString("UserSession", sessionData);

            var response = new ServiceResponse<Session>
            {
                Data = session,
                Success = true
            };

            return response;
        }
    }
}
