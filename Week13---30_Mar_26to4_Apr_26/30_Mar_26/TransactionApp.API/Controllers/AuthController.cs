using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly TokenService _tokenService;

    public AuthController(AppDbContext context, TokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDTO dto)
    {
        var user = _context.Users
            .FirstOrDefault(u => u.Username == dto.Username && u.Password == dto.Password);

        if (user == null) return Unauthorized();

        var token = _tokenService.CreateToken(user);

        return Ok(new { token });
    }
}