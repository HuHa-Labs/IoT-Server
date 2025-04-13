using Microsoft.AspNetCore.Mvc;

namespace IoT_Server.Controllers;

[ApiController]
public class ServerStatus : ControllerBase
{
    [HttpGet("api/")]
    public ObjectResult GetApiStatus()
    {
        return StatusCode(200, new { message = "OK" });
    }
}