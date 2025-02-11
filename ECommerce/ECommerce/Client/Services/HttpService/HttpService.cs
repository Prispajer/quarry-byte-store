using ECommerce.Shared.Models;

namespace ECommerce.Client.Services.HttpService
{
    public class HttpService: IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<T>> SendRequestAsync<T>(HttpMethod method, string url, object? data = null)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(method, url);

            if (data != null && (method == HttpMethod.Patch || method == HttpMethod.Post || method == HttpMethod.Put))
            {
                requestMessage.Content = JsonContent.Create(data);
            }

            try
            {
                var request = await _httpClient.SendAsync(requestMessage);

                if (request.IsSuccessStatusCode)
                {
                    var response = await request.Content.ReadFromJsonAsync<ServiceResponse<T>>();

                    if (response == null)
                    {
                        return new ServiceResponse<T>
                        {
                            Data = default,
                            Message = "There was a problem while retrieving data!",
                            Success = false
                        };
                    }

                    return response;
                }
                else
                {
                    return new ServiceResponse<T>
                    {
                        Data = default,
                        Message = $"Failed to request data. Status code: {request.StatusCode}",
                        Success = false
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<T>
                {
                    Data = default,
                    Message = $"An error occurred: {ex.Message}",
                    Success = false
                };
            }
        }
    }
}
