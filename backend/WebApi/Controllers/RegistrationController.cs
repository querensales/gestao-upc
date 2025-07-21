using AppService.Domain;
using AppService.Domain.Registration.Request;
using AppService.Domain.Registration.Validator;
using AppService.Extension;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegistrationController : ControllerBase
{
    private readonly IRegistrationService _registrationService;
    private readonly AppDbContext _appDbContext;
    public RegistrationController(
        IRegistrationService registrationService, 
        AppDbContext appDbContext)
    {
        _registrationService = registrationService;
        _appDbContext = appDbContext;
    }


    [HttpPost("add-account")]
    public async Task<IActionResult> AddAccout(AddAccountRequest request)
    {
        var validator = new AddAccountRequestValidator();
        var validate = validator.Validate(request);
        if (!validate.IsValid)
        {
            var exception = new CustomValidationException(validate?.Errors);
            return BadRequest(new { Errors = exception.Erros });
        }
        await _registrationService.AddAccountAsync(request);
        return Created();
    }


    [HttpPost("add-credit-card")]
    public async Task<IActionResult> AddCreditCard(AddCreditCardRequest request)
    {
        var validator = new AddCreditCardRequestValidator();
        var validate = validator.Validate(request);
        if (!validate.IsValid)
        {
            var exception = new CustomValidationException(validate?.Errors);
            return BadRequest(new { Errors = exception.Erros });
        }
        await _registrationService.AddCreditCardAsync(request);
        return Created();
    }

    [HttpPost("add-category")]
    public async Task<IActionResult> AddCategory(AddCategoryRequest request)
    {
        var validator = new AddCategoryRequestValidator();
        var validate = validator.Validate(request);
        if (!validate.IsValid)
        {
            var exception = new CustomValidationException(validate?.Errors);
            return BadRequest(new { Errors = exception.Erros });
        }
        await _registrationService.AddCategoryAsync(request);
        return Created();
    }

    [HttpPost("add-record")]
    [Authorize]
    public async Task<IActionResult> AddRecord([FromBody] AddRecordRequest request)
    {
        await _registrationService.AddRecordAsync(request);
        return StatusCode(201);
    }

    [HttpPut("update-record")]
    [Authorize]
    public async Task<IActionResult> UpdateRecord([FromBody] UpdateRecordRequest request)
    {
        await _registrationService.UpdateRecordAsync(request);
        return NoContent();
    }

    [HttpDelete("delete-record/{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteRecord([FromRoute] Guid id)
    {
        await _registrationService.DeleteRecordAsync(id);
        return NoContent();
    }

    [HttpGet("get-accounts")]
    public async Task<IActionResult> Accounts()
    {
        var accounts = await _registrationService.GetAccountsAsync();
        return Ok(accounts);
    }

    [HttpGet("get-credit-cards")]
    public async Task<IActionResult> CreditCards()
    {
        var creditCards = await _registrationService.GetCreditCardsAsync();
        return Ok(creditCards);
    }

    [HttpGet("get-categories")]
    public async Task<IActionResult> Categories()
    {
        var categories = await _registrationService.GetCategoriesAsync();
        return Ok(categories);
    }
}
