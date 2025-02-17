using ECommerce.Server.Services.SessionService;
using ECommerce.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet("getsession")]
        public ActionResult<ServiceResponse<Session>> GetSession()
        {
            var session = _sessionService.GetSession();

            if (!session.Success)
            {
                return Conflict(session);
            }
            return Ok(session);
        }

    }
}
