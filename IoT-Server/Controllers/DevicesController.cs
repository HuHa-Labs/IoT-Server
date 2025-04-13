using Microsoft.AspNetCore.Mvc;

namespace IoT_Server.Controllers;

[ApiController]
[Route("api/devices")]
public class DevicesController : ControllerBase
{
    [HttpGet("api/devices")]
    public ObjectResult GetApiStatus()
    {
        return StatusCode(200, new { message = "OK" });
    }
}