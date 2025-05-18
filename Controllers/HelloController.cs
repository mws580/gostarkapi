using Microsoft.AspNetCore.Mvc;

namespace StarkAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "Hello from a separate controller!" });
        }
    }
}
