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
        private ILogger<SessionController> _logger;

        public SessionController(ISessionService sessionService, ILogger<SessionController> logger)
        {
            _sessionService = sessionService;
            _logger = logger;
        }

        [HttpGet("getsession")]
        public ActionResult<ServiceResponse<Session>> GetSession()
        {
            try
            {
                var result = _sessionService.GetSession();
                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get session error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
