using EventBooking.API.DTOs;
using EventBooking.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtService _jwtService;

        public AuthController(UserManager<IdentityUser> userManager, JwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            // Assign "User" role by default on registration
            await _userManager.AddToRoleAsync(user, "User");

            return Ok(new { message = "Registration successful" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
                return Unauthorized(new { message = "Invalid credentials" });

            // Get roles for the user
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault() ?? "User";

            var token = _jwtService.GenerateToken(user, role);

            return Ok(new AuthResponseDto
            {
                Token = token,
                Email = user.Email!,
                FullName = user.UserName!,
                Role = role
            });
        }
    }
}