using Microsoft.AspNetCore.Mvc;

namespace OpenStore.Infra.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController(ILogger<HelloWorldController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello, World!");
        }
    }
}
