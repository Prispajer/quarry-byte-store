using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ECommerce.Client.Services.HttpService;
using ECommerce.Shared.Dto.User;
using ECommerce.Shared.Models;
using ECommerce.Shared.Models.User;

namespace ECommerce.Client.Services.SessionService
{
    public class SessionService : ISessionService
    {
        private readonly HttpClient _http;
        private readonly IHttpService _httpService;
        public event Action? OnChange;

        public SessionService(HttpClient http, IHttpService httpService)
        {
            _http = http;
            _httpService = httpService;
        }

        public async Task<ServiceResponse<Session>> GetSessionAsync()
        {
            return await _httpService.SendRequestAsync<Session>(HttpMethod.Get, "api/session/getsession");
        }

        public async Task<ServiceResponse<Session>> UpdateSessionAsync(Session session)
        {
            return await _httpService.SendRequestAsync<Session>(HttpMethod.Post, "api/session/updatesession", session);
        }

    }
}
