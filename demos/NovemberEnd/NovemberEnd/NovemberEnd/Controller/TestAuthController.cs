using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NovemberEnd.Controller;

[Authorize(AuthenticationSchemes = "Cookie", Policy = "AlcoholPolicy", Roles = "Admin")]
public class TestAuthController : ControllerBase
{
    private readonly IAuthorizationService authorizationService;

    public TestAuthController(IAuthorizationService authorizationService)
    {
        this.authorizationService = authorizationService;
    }
    
    [HttpGet]
    [Authorize(Policy = "CreateUsersPolicy")]
    public IActionResult Index()
    {
        User.Claims.
        this.authorizationService.AuthorizeAsync()
        return this.Ok();
    }
}