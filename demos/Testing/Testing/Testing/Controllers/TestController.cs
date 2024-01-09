using Microsoft.AspNetCore.Mvc;
using Testing.Service;

namespace Testing.Controllers;

[ApiController]
[Route("/test")]
public class TestController : ControllerBase
{
    private readonly ILightService lightService;

    public TestController(ILightService lightService)
    {
        this.lightService = lightService;
    }
    
    [HttpGet("{color}")]
    public IActionResult Test(string color)
    {
        return this.Ok(this.lightService.GetLightsByColor(color));
    }
}