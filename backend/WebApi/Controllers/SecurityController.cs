using AppService.Domain;
using AppService.Domain.Account.Request;
using AppService.Domain.Account.Validator;
using AppService.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SecurityController : ControllerBase
{
    private readonly ISecurityService _securityService;
    private readonly IConfiguration _configuration;
    private readonly AppDbContext _appDbContext;
    public SecurityController(
        ISecurityService securityService,
        IConfiguration configuration,
        AppDbContext appDbContext)
    {
        _securityService = securityService;
        _configuration = configuration;
        _appDbContext = appDbContext;
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
        var validator = new AddUserValidator(_appDbContext);
        var validate = validator.Validate(request);
        if (!validate.IsValid)
        {
            var exception = new CustomValidationException(validate?.Errors);
            return BadRequest(new { Errors = exception.Erros }); // Retorna um objeto JSON com os erros formatados
        }
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
