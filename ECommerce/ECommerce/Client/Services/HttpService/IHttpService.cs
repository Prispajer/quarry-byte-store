using ECommerce.Shared.Models;

namespace ECommerce.Client.Services.HttpService
{
    public interface IHttpService
    {
        Task<ServiceResponse<T>> SendRequestAsync<T>(HttpMethod method, string url, object? data = null);
    }
}
