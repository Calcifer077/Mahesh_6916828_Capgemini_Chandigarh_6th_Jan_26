using Microsoft.AspNetCore.Mvc;
using ProductApi.Services;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromQuery] string username, [FromQuery] string password)
        {
            // Hardcoded credentials for this case study
            if (username == "admin" && password == "admin123")
            {
                var token = _tokenService.GenerateToken(username);
                return Ok(new
                {
                    message = "Login successful",
                    token = token
                });
            }

            return Unauthorized(new { message = "Invalid username or password" });
        }
    }
}