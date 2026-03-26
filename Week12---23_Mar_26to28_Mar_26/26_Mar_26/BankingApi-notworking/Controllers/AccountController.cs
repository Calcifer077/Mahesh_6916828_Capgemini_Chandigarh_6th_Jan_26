using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public AccountController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("details")]
    [Authorize] // 🔐 Requires JWT
    public IActionResult GetAccountDetails()
    {
        // Get UserId from JWT token
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        Console.WriteLine(ClaimTypes.NameIdentifier);

        var account = _context.Accounts.FirstOrDefault(a => a.UserId == userId);

        if (account == null)
            return NotFound();

        var dto = _mapper.Map<AccountDetailsDto>(account);

        return Ok(dto);
    }
}