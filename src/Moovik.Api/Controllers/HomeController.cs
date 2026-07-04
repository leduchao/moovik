using Microsoft.AspNetCore.Mvc;
using Moovik.Api.Common.Constants;

namespace Moovik.Api.Controllers;

[ApiController]
[Route(ApiPath.BaseUrl)]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Greeting()
    {
        return Ok(new { message = "Welcome to Moovik!"});
    }
}