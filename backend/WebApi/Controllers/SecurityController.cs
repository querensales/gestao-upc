using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using AppService.Domain;
using AppService.Domain.Account.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
}
