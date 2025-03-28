using ECommerce.Shared.Models;
using ECommerce.Server.Services.TokenService;

namespace ECommerce.Server.Services.SessionService
{
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly ITokenService _tokenService;

        public SessionService(IHttpContextAccessor httpContext, ITokenService tokenService)
        {
            _httpContext = httpContext;
            _tokenService = tokenService;
        }

        public ServiceResponse<Session> GetSession()
        {
            var token = _httpContext.HttpContext?.Request.Cookies["AuthToken"];

            if (string.IsNullOrEmpty(token))
            {
                return new ServiceResponse<Session>
                {
                    Data = null,
                    Success = false,
                    Message = "Session not found or empty"
                };
            }

            var session = _tokenService.DecodeToken(token);

            if (session == null)
            {
                return new ServiceResponse<Session>
                {
                    Data = null,
                    Success = false,
                    Message = "Invalid token!"
                };
            }

            return new ServiceResponse<Session>
            {
                Data = session,
                Success = true
            };
        }
    }
}
