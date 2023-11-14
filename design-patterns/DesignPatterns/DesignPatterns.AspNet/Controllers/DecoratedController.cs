using DesignPatterns.AspNet.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DesignPatterns.AspNet.Controllers;

[Route("/decorator")]
public class DecoratedController : Controller
{
    private readonly ILogger<DecoratedController> logger;

    public DecoratedController(ILogger<DecoratedController> logger)
    {
        this.logger = logger;
    }
    
    [HttpGet("")]
    [ServiceFilter(typeof(TestActionFilterAttribute))]
    public IActionResult Index()
    {
        this.logger.LogInformation("Index action has been executed");
        return this.Ok();
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        this.logger.LogInformation("After the execution");
        base.OnActionExecuted(context);
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        this.logger.LogInformation("Before the execution");
        base.OnActionExecuting(context);
    }
}