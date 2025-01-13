using System.Net;
using AppService.Domain;
using AppService.Domain.Account.Request;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SecurityController : ControllerBase
{
    private readonly ISecurityService _securityService;
    public SecurityController(ISecurityService securityService)
    {
        _securityService = securityService;
    }


    [HttpPost]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        try
        {
            _securityService.SignIn(request).Wait();

        }
        catch (Exception)
        {

            
        }
        return Ok(HttpStatusCode.Accepted);
    }
}
