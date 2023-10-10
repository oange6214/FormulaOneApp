
using Microsoft.AspNetCore.Mvc;

namespace FormulaOneApp.Controllers;

[Route("api/[controller]")] // api/teams
[ApiController]
public class TeamsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello, from the controller");
    }
}