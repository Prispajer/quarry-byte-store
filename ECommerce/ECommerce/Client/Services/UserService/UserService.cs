using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ECommerce.Shared;

namespace ECommerce.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;

        public UserService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<User>> LoginAsync(string email, string password)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<User>>($"api/user/login?email={email}&password={password}");
            return response;
        }

        public async Task<ServiceResponse<User>> RegisterAsync(string email, string password, string name, bool isAdmin)
        {
            var response = await _http.PostAsJsonAsync("api/user/register", new { email, password, name, isAdmin });
            return await response.Content.ReadFromJsonAsync<ServiceResponse<User>>();
        }

        public async Task<ServiceResponse<User>> ChangePasswordAsync(int id, string oldPassword, string newPassword)
        {
            var response = await _http.PatchAsync($"api/user/resetpassword?id={id}&oldPassword={oldPassword}&newPassword={newPassword}", null);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<User>>();
        }

        public async Task<ServiceResponse<User>> ChangeForgottenPasswordAsync(string email, string newPassword)
        {
            var response = await _http.PatchAsync($"api/user/forgotpassword?email={email}&newPassword={newPassword}", null);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<User>>();
        }
    }
}
