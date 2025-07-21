using Microsoft.AspNetCore.Mvc;
using AppService.Domain;
using AppService.Domain.Registration.Request;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecordController : ControllerBase
{
    private readonly IRecordService _recordService;
    public RecordController(IRecordService recordService)
    {
        _recordService = recordService;
    }

    [HttpPost("add")]
    [Authorize]
    public async Task<IActionResult> AddRecord([FromBody] AddRecordRequest request)
    {
        await _recordService.AddRecordAsync(request);
        return StatusCode(201);
    }

    [HttpPut("update")]
    [Authorize]
    public async Task<IActionResult> UpdateRecord([FromBody] UpdateRecordRequest request)
    {
        await _recordService.UpdateRecordAsync(request);
        return NoContent();
    }

    [HttpDelete("delete/{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteRecord([FromRoute] Guid id)
    {
        await _recordService.DeleteRecordAsync(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetRecordById([FromRoute] Guid id)
    {
        var result = await _recordService.GetRecordByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("all")]
    [Authorize]
    public async Task<IActionResult> GetAllRecords()
    {
        var result = await _recordService.GetAllRecordsAsync();
        return Ok(result);
    }

    [HttpGet("balance")]
    [Authorize]
    public async Task<IActionResult> GetCurrentMonthBalance()
    {
        var result = await _recordService.GetCurrentMonthBalanceAsync();
        return Ok(result);
    }
} 