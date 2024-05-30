using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ECommerce.Client.Services.SessionService;
using ECommerce.Shared;

namespace ECommerce.Client.Services.UserService
{
    public class SessionService : ISessionService
    {
        private readonly HttpClient _http;

        public SessionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<Session?>> GetSessionAsync()
        {
            var sessionData = await _http.GetFromJsonAsync<ServiceResponse<Session?>>("api/session/getsession");

            if (sessionData.Success)
            {
                return sessionData;
            }
            else
            {
                return new ServiceResponse<Session?>
                {
                    Success = false,
                    Message = "Nie udało się pobrać sesji"
                };
            }
        }

        public async Task<ServiceResponse<Session?>> ClearSessionAsync()
        {
           var sessionData = await _http.GetFromJsonAsync<ServiceResponse<Session?>>("api/session/deletesession");
           
            if (sessionData.Success)
            {
                return new ServiceResponse<Session?>
                {
                    Data = sessionData.Data,
                    Success = true,
                    Message = "Pomyślnie wylogowano użytkownika!"
                };
            }
            else
            {
                return new ServiceResponse<Session?>
                {
                    Success = false,
                    Message = "Nie udało się wylogować użytkownika"
                };
            }
        }
    }
}
