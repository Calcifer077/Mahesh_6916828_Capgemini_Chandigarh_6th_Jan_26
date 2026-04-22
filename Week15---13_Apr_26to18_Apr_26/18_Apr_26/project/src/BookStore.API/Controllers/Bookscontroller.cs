using BookStore.Application.DTOs.Books;
using BookStore.Application.DTOs.Common;
using BookStore.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

/// <summary>
/// Manages books: browsing (public), CRUD (Admin only), search, and wishlist.
/// </summary>
[ApiController]
[Route("api/v1/books")]
[Produces("application/json")]
public class BooksController(IBookService bookService) : ControllerBase
{
    // -------------------------------------------------------------------------
    // GET api/v1/books
    // -------------------------------------------------------------------------
    /// <summary>Get all books with author, category, and publisher details.</summary>
    /// <response code="200">List of books returned.</response>
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<BookDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var books = await bookService.GetAllBooksAsync();
        return Ok(ApiResponse<IEnumerable<BookDto>>.Ok(books));
    }

    // -------------------------------------------------------------------------
    // GET api/v1/books/{id}
    // -------------------------------------------------------------------------
    /// <summary>Get a single book by ID, including its reviews.</summary>
    /// <param name="id">The book ID.</param>
    /// <response code="200">Book found.</response>
    /// <response code="404">Book not found.</response>
    [HttpGet("{id:int}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResponse<BookDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var book = await bookService.GetBookByIdAsync(id);
        return Ok(ApiResponse<BookDto>.Ok(book));
    }

    // -------------------------------------------------------------------------
    // GET api/v1/books/search?q=...
    // -------------------------------------------------------------------------
    /// <summary>Search books by title or author name.</summary>
    /// <param name="q">Search keyword.</param>
    /// <response code="200">Matching books returned.</response>
    /// <response code="400">Search query is required.</response>
    [HttpGet("search")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<BookDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Search([FromQuery] string q)
    {
        if (string.IsNullOrWhiteSpace(q))
            return BadRequest(ApiResponse<object>.Fail("Search query cannot be empty."));

        var books = await bookService.SearchAsync(q);
        return Ok(ApiResponse<IEnumerable<BookDto>>.Ok(books));
    }

    // -------------------------------------------------------------------------
    // GET api/v1/books/category/{categoryId}
    // -------------------------------------------------------------------------
    /// <summary>Get all books belonging to a specific category.</summary>
    /// <param name="categoryId">The category ID.</param>
    [HttpGet("category/{categoryId:int}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<BookDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByCategory(int categoryId)
    {
        var books = await bookService.GetBooksByCategoryAsync(categoryId);
        return Ok(ApiResponse<IEnumerable<BookDto>>.Ok(books));
    }

    // -------------------------------------------------------------------------
    // GET api/v1/books/low-stock          [Admin]
    // -------------------------------------------------------------------------
    /// <summary>Get books with stock at or below the threshold (default 5).</summary>
    /// <param name="threshold">Stock threshold (default = 5).</param>
    [HttpGet("low-stock")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<BookDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetLowStock([FromQuery] int threshold = 5)
    {
        var books = await bookService.GetLowStockBooksAsync(threshold);
        return Ok(ApiResponse<IEnumerable<BookDto>>.Ok(books));
    }

    // -------------------------------------------------------------------------
    // POST api/v1/books                   [Admin]
    // -------------------------------------------------------------------------
    /// <summary>Create a new book. Requires Admin role.</summary>
    /// <response code="201">Book created successfully.</response>
    /// <response code="400">Validation failed.</response>
    /// <response code="401">Not authenticated.</response>
    /// <response code="403">Not authorized (Admin only).</response>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ApiResponse<BookDto>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Create([FromBody] BookCreateDto dto)
    {
        var book = await bookService.CreateBookAsync(dto);
        return CreatedAtAction(
            nameof(GetById),
            new { id = book.BookId },
            ApiResponse<BookDto>.Ok(book, "Book created successfully")
        );
    }

    // -------------------------------------------------------------------------
    // PUT api/v1/books/{id}               [Admin]
    // -------------------------------------------------------------------------
    /// <summary>Update an existing book's details. Requires Admin role.</summary>
    /// <param name="id">The book ID to update.</param>
    /// <response code="204">Book updated successfully.</response>
    /// <response code="404">Book not found.</response>
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] BookUpdateDto dto)
    {
        await bookService.UpdateBookAsync(id, dto);
        return NoContent();
    }

    // -------------------------------------------------------------------------
    // PATCH api/v1/books/{id}/stock       [Admin]
    // -------------------------------------------------------------------------
    /// <summary>Update only the stock quantity of a book. Requires Admin role.</summary>
    /// <param name="id">The book ID.</param>
    /// <param name="dto">New stock value.</param>
    [HttpPatch("{id:int}/stock")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateStock(int id, [FromBody] UpdateStockDto dto)
    {
        await bookService.UpdateStockAsync(id, dto.Stock);
        return NoContent();
    }

    // -------------------------------------------------------------------------
    // DELETE api/v1/books/{id}            [Admin]
    // -------------------------------------------------------------------------
    /// <summary>Delete a book by ID. Requires Admin role.</summary>
    /// <param name="id">The book ID to delete.</param>
    /// <response code="204">Book deleted.</response>
    /// <response code="404">Book not found.</response>
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await bookService.DeleteBookAsync(id);
        return NoContent();
    }
}
