using Microsoft.AspNetCore.Mvc;

namespace DeveloperStore.Api.Controllers
{
    [Route("api/health")]
    public class HealthController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Status OK.");
        }
    }
}
