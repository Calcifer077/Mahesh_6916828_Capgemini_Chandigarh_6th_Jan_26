using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.DTOs.Books;

public record BookDto(
    int BookId,
    string Title,
    string ISBN,
    decimal Price,
    int Stock,
    string? ImageUrl,
    string CategoryName,
    string AuthorName,
    string PublisherName
);

public record BookCreateDto(
    [Required] string Title,
    [Required] string ISBN,
    [Range(0.01, double.MaxValue)] decimal Price,
    [Range(0, int.MaxValue)] int Stock,
    string? ImageUrl,
    int CategoryId,
    int AuthorId,
    int PublisherId
);

public record BookUpdateDto(
    string? Title,
    decimal? Price,
    int? Stock,
    string? ImageUrl,
    int? CategoryId,
    int? AuthorId,
    int? PublisherId
);
