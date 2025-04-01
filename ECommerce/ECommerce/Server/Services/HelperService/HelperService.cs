using ECommerce.Shared.Models;

namespace ECommerce.Server.Services.HelperService
{
    public class HelperService: IHelperService
    {
        public ServiceResponse<T>CreateResponse<T>(T data, string nessage = "")
        {
            if (data == null)
            {
                return new ServiceResponse<T>
                {
                    Success = false,
                    Data = default,
                    Message = nessage
                };
            }

            return new ServiceResponse<T>
            {
                Success = true,
                Data = data,
                Message = ""
            };
        }
    }
}
