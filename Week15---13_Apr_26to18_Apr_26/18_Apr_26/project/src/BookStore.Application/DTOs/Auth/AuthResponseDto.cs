namespace BookStore.Application.DTOs.Auth;

public record AuthResponseDto(string Token, string RefreshToken, string FullName, string Role);
