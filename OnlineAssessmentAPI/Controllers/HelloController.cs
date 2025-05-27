using Microsoft.AspNetCore.Mvc;

namespace OnlineAssessmentAPI.Controllers
{
   [ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("Hello from Azure API!");

    [HttpGet("{name}")]
    public IActionResult Get(string name) => Ok($"Hello, {name}!");
}
}
