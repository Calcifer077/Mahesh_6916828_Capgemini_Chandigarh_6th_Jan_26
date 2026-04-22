// Auth DTOs
using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.DTOs.Auth;

public record UserLoginDto([Required, EmailAddress] string Email, [Required] string Password);
