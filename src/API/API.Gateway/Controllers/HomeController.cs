using Microsoft.AspNetCore.Mvc;

namespace API.Gateway.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public string Get()
    {
        return "hello Gateway";
    }
}