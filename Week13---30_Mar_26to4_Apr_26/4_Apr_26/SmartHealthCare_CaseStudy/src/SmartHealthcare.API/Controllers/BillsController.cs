using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.API.Services.Interfaces;
using SmartHealthcare.Models.DTOs;

namespace SmartHealthcare.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BillsController : ControllerBase
{
    private readonly IBillService _service;

    public BillsController(IBillService service) => _service = service;

    [HttpGet("appointment/{appointmentId:int}")]
    public async Task<IActionResult> GetByAppointmentId(int appointmentId)
    {
        var bill = await _service.GetByAppointmentIdAsync(appointmentId);
        if (bill == null)
            return NotFound(new ErrorResponseDTO { Message = "Bill not found", StatusCode = 404 });
        return Ok(bill);
    }

    [HttpPatch("{id:int}/pay")]
    [Authorize(Roles = "Patient")]
    public async Task<IActionResult> Pay(int id)
    {
        try
        {
            var result = await _service.MarkAsPaidAsync(id);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ErrorResponseDTO { Message = ex.Message, StatusCode = 404 });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new ErrorResponseDTO { Message = ex.Message, StatusCode = 400 });
        }
    }
}
