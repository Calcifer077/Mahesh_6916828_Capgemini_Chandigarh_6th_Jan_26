namespace BookStore.Application.DTOs.Auth;

using System.ComponentModel.DataAnnotations;

public record UserRegisterDto(
    [Required] string FullName,
    [Required, EmailAddress] string Email,
    [Required, MinLength(8)] string Password,
    string? Phone
);
