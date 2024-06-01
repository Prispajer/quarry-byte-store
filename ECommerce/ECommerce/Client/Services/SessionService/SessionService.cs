using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ECommerce.Shared;

namespace ECommerce.Client.Services.SessionService
{
    public class SessionService : ISessionService
    {
        private readonly HttpClient _http;
        public event Action OnChange;

        public SessionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<Session>> GetSessionAsync()
        {
            var sessionData = await _http.GetFromJsonAsync<ServiceResponse<Session>>("api/session/getsession");

            return sessionData;
        }

        public async Task<ServiceResponse<Session>> UpdateSessionAsync(Session session)
        {
            var response = await _http.PostAsJsonAsync("api/session/updatesession", session);

            return await response.Content.ReadFromJsonAsync<ServiceResponse<Session>>();
        }

    }
}
