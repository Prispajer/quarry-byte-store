using ECommerce.Server.Services.SessionService;
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
        public async Task<ActionResult<ServiceResponse<Session>>> GetSessionInfo()
        {
            var session = await _sessionService.GetSessionAsync();
            if (!session.Success)
            {
                return Conflict(session);

            }
            return Ok(session);
        }


        [HttpDelete("deletesession")]
        public async Task<ActionResult> ClearSession()
        {
            await _sessionService.ClearSessionAsync();
            return NoContent();
        }
    }
}
