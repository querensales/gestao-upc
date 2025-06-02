using AppService.Domain;
using AppService.Domain.Security.Request;
using AppService.Domain.Security.Validator;
using AppService.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class SecurityController : ControllerBase
{
    private readonly ISecurityService _securityService;
    private readonly AppDbContext _appDbContext;
    public SecurityController(
        ISecurityService securityService,
        AppDbContext appDbContext)
    {
        _securityService = securityService;
        _appDbContext = appDbContext;
    }


    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            var token = await _securityService.SignIn(request);

            return Ok(token);
        }
        catch(CustomValidationException ex)
        {
            return BadRequest(ex.Erros);
        }
        catch (Exception)
        {

            throw;
        }
        
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
