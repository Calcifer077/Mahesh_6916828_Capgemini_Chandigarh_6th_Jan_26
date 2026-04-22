using System.Security.Claims;
using BookStore.Application.DTOs.Auth;
using BookStore.Application.DTOs.Common;
using BookStore.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

/// <summary>
/// Handles user authentication: registration, login, refresh tokens, and profile.
/// </summary>
[ApiController]
[Route("api/v1/auth")]
[Produces("application/json")]
public class AuthController(IAuthService authService) : ControllerBase
{
    // -------------------------------------------------------------------------
    // POST api/v1/auth/register
    // -------------------------------------------------------------------------
    /// <summary>Register a new customer account.</summary>
    /// <response code="200">Registration successful, returns JWT token.</response>
    /// <response code="400">Validation failed or email already in use.</response>
    [HttpPost("register")]
    [ProducesResponseType(typeof(ApiResponse<AuthResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
    {
        var result = await authService.RegisterAsync(dto);
        return Ok(ApiResponse<AuthResponseDto>.Ok(result, "Registration successful"));
    }

    // -------------------------------------------------------------------------
    // POST api/v1/auth/login
    // -------------------------------------------------------------------------
    /// <summary>Login with email and password. Returns JWT + refresh token.</summary>
    /// <response code="200">Login successful.</response>
    /// <response code="401">Invalid credentials.</response>
    [HttpPost("login")]
    [ProducesResponseType(typeof(ApiResponse<AuthResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
    {
        var result = await authService.LoginAsync(dto);
        return Ok(ApiResponse<AuthResponseDto>.Ok(result, "Login successful"));
    }

    // -------------------------------------------------------------------------
    // POST api/v1/auth/refresh
    // -------------------------------------------------------------------------
    /// <summary>Exchange a refresh token for a new access token.</summary>
    /// <response code="200">New access token issued.</response>
    /// <response code="401">Invalid or expired refresh token.</response>
    [HttpPost("refresh")]
    [ProducesResponseType(typeof(ApiResponse<AuthResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto dto)
    {
        var result = await authService.RefreshTokenAsync(dto.RefreshToken);
        return Ok(ApiResponse<AuthResponseDto>.Ok(result));
    }

    // -------------------------------------------------------------------------
    // GET api/v1/auth/me
    // -------------------------------------------------------------------------
    /// <summary>Get the currently authenticated user's profile.</summary>
    /// <response code="200">User profile returned.</response>
    /// <response code="401">Not authenticated.</response>
    [HttpGet("me")]
    [Authorize]
    [ProducesResponseType(typeof(ApiResponse<UserProfileDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMe()
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var profile = await authService.GetProfileAsync(userId);
        return Ok(ApiResponse<UserProfileDto>.Ok(profile));
    }

    // -------------------------------------------------------------------------
    // PUT api/v1/auth/me
    // -------------------------------------------------------------------------
    /// <summary>Update the currently authenticated user's profile.</summary>
    /// <response code="204">Profile updated successfully.</response>
    /// <response code="401">Not authenticated.</response>
    [HttpPut("me")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto dto)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        await authService.UpdateProfileAsync(userId, dto);
        return NoContent();
    }

    // -------------------------------------------------------------------------
    // POST api/v1/auth/change-password
    // -------------------------------------------------------------------------
    /// <summary>Change password for the currently authenticated user.</summary>
    /// <response code="204">Password changed.</response>
    /// <response code="400">Old password incorrect.</response>
    [HttpPost("change-password")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        await authService.ChangePasswordAsync(userId, dto);
        return NoContent();
    }

    // -------------------------------------------------------------------------
    // POST api/v1/auth/logout   (stateless JWT — client just discards token)
    // -------------------------------------------------------------------------
    /// <summary>Invalidate the current refresh token server-side.</summary>
    /// <response code="204">Refresh token revoked.</response>
    [HttpPost("logout")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Logout([FromBody] RefreshTokenDto dto)
    {
        await authService.RevokeRefreshTokenAsync(dto.RefreshToken);
        return NoContent();
    }
}
