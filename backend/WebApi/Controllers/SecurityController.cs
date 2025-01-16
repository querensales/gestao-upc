using AppService.Domain;
using AppService.Domain.Account.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SecurityController : ControllerBase
{
    private readonly ISecurityService _securityService;
    private readonly IConfiguration _configuration;
    public SecurityController(
        ISecurityService securityService,
        IConfiguration configuration)
    {
        _securityService = securityService;
        _configuration = configuration;
    }


    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {

        var token = await _securityService.SignIn(request);

        return Ok(token);
    }

    [HttpPost("add-user")]
    [AllowAnonymous]
    public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
    {
        await _securityService.AddUser(request);

        return Accepted();
    }

    [HttpPut("{email}")]
    [AllowAnonymous]
    public async Task<IActionResult> ForgotPassword(string email)
    {
        await _securityService.ForgotPassword(email);

        return Accepted();
    }
}
