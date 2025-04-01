using ECommerce.Shared.Models;

namespace ECommerce.Server.Services.HelperService
{
    public interface IHelperService
    {
        ServiceResponse<T> CreateResponse<T>(T data, string nessage = "");
    }
}
