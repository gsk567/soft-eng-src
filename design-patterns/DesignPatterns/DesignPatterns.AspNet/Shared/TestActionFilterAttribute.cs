using Microsoft.AspNetCore.Mvc.Filters;

namespace DesignPatterns.AspNet.Shared;

public class TestActionFilterAttribute : ActionFilterAttribute
{
    private readonly ILogger<TestActionFilterAttribute> logger;

    public TestActionFilterAttribute(ILogger<TestActionFilterAttribute> logger)
    {
        this.logger = logger;
    }
    
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        this.logger.LogInformation("Test Action Filter Before");
        base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        this.logger.LogInformation("Test Action Filter After");
        base.OnActionExecuted(context);
    }
}