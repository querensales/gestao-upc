using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppService.Domain;
using AppService.Domain.Registration.Request;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IRegistrationService _registrationService;
    public AccountController(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }

    [HttpPost]
    [Route("add")]
    [Authorize]
    public async Task<IActionResult> AddAccount([FromBody] AddAccountRequest request)
    {
        await _registrationService.AddAccountAsync(request);
        return StatusCode(201);
    }
}
