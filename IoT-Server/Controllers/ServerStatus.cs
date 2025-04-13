using Microsoft.AspNetCore.Mvc;

namespace IoT_Server.Controllers;

[ApiController]
public class ServerStatus : ControllerBase
{
    [HttpGet("api/")]
    public ActionResult<string> GetApiStatus()
    {
        return Ok("OK");
    }

    [HttpGet("api/dummyError")]
    public ActionResult GetDummyError()
    {
        return BadRequest();
    }
}