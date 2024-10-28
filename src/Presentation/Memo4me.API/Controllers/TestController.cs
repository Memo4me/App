using Microsoft.AspNetCore.Mvc;

namespace Memo4me.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("test")]
    public IActionResult GetTest()
    {
        return Ok("test");
    }
}