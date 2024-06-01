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

        public async Task<ServiceResponse<User>> LoginAsync(UserLoginRequest request)
        {
                var response = await _http.PostAsJsonAsync("api/user/login", request);

                if (response.IsSuccessStatusCode)
                {
                    var serviceResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<User>>();
                    return serviceResponse;
                }
                else
                {
                    return new ServiceResponse<User>
                    {
                        Success = false,
                        Message = "Could not authenticate user"
                    };
                }
        }

        public async Task<ServiceResponse<User>> RegisterAsync(UserRegistrationRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/user/register", request);
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
